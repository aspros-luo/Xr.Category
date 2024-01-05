using Aspros.SaaS.System.Domain.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Tsp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aspros.SaaS.System.Infrastructure
{
    public class JwtHandler(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;

        private string issuer => _configuration["Jwt:Issuer"];
        private string audience => _configuration["Jwt:Audience"];
        private string tokenExpiresTime => _configuration["Jwt:TokenExpiresTime"];
        private string refreshTokenExpiresTime => _configuration["Jwt:RefreshTokenExpiresTime"];
        private SymmetricSecurityKey secretKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        /// <summary>
        /// 生成AccessToken
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GenerateAccessToken(User user)
        {
            // 1. 定义需要使用到的Claims
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, "u_admin"), //HttpContext.User.Identity.Name
            new Claim(ClaimTypes.Role, "r_admin"), //HttpContext.User.IsInRole("r_admin")
            new Claim(JwtRegisteredClaimNames.Jti, "admin"),
            new Claim("tenant_id", user.TenantId.ToString()),
            new Claim("user_id", user.Id.ToString()),
            new Claim("user_name", user.UserName)
        };

            // 2. 从 appsettings.json 中读取SecretKey
            //var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            // 3. 选择加密算法 生成Credentials
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // 4. 根据以上，生成token
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: issuer,                    // 发布者
                audience: audience,                // 接收者
                notBefore: DateTime.Now,                                                          // token签发时间
                expires: DateTime.Now.AddHours(double.Parse(tokenExpiresTime)),                                             // token过期时间
                claims: claims,                                                                   // 该token内存储的自定义字段信息
                signingCredentials: signingCredentials   // 用于签发token的秘钥算法
            );

            // 5. 将token变为string
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return token;
        }

        /// <summary>
        /// 生成RefreshToken
        /// </summary>
        /// <returns></returns>
        public string GenerateRefreshToken()
        {
            // 获取SecurityKey
            //var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var refClaims = new[]
            {
               new Claim("role","refresh")
            };
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var refreshToken = new JwtSecurityToken(
                issuer: issuer,                    // 发布者
                audience: audience,                // 接收者
                notBefore: DateTime.Now,                                                          // token签发时间
                expires: DateTime.Now.AddDays(double.Parse(refreshTokenExpiresTime)),                                             // token过期时间
                claims: refClaims,                                                                   // 该token内存储的自定义字段信息
                signingCredentials: signingCredentials   // 用于签发token的秘钥算法
            );

            // 返回成功信息，写出token
            return new JwtSecurityTokenHandler().WriteToken(refreshToken);
        }

        /// <summary>
        /// 刷新accessToken
        /// </summary>
        /// <param name="accessToken">过期的accessToken</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string RefreshToken(string accessToken)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            bool isCan = jwtSecurityTokenHandler.CanReadToken(accessToken);//验证Token格式
            if (!isCan)
                throw new Exception("传入访问令牌格式错误");
            //var jwtToken = jwtSecurityTokenHandler.ReadJwtToken(refreshtoken);//转换类型为token，不用这一行
            var validateParameter = new TokenValidationParameters()//验证参数
            {
                ValidateAudience = true,
                // 验证发布者
                ValidateIssuer = true,
                // 验证过期时间
                ValidateLifetime = false,
                // 验证秘钥
                ValidateIssuerSigningKey = true,
                // 读配置Issure
                ValidIssuer = issuer,
                // 读配置Audience
                ValidAudience = audience,
                // 设置生成token的秘钥
                IssuerSigningKey = secretKey
            };

            //验证传入的过期的AccessToken
            SecurityToken validatedToken;
            try
            {
                jwtSecurityTokenHandler.ValidateToken(accessToken, validateParameter, out validatedToken);//微软提供的验证方法。那个out传出的参数，类型是是个抽象类，记得转换
            }
            catch (SecurityTokenException)
            {
                throw new Exception("传入AccessToken被修改");
            }
            // 获取SecurityKey
            var jwtToken = validatedToken as JwtSecurityToken;//转换一下
            var access_Token = new JwtSecurityToken(
                    issuer: issuer,                    // 发布者
                    audience: audience,                // 接收者
                    notBefore: DateTime.Now,                                                          // token签发时间
                    expires: DateTime.Now.AddHours(double.Parse(tokenExpiresTime)),                                                      // token过期时间
                    claims: jwtToken.Claims,                                                                   // 该token内存储的自定义字段信息
                    signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)    // 用于签发token的秘钥算法
                );
            // 返回成功信息，写出token
            return new JwtSecurityTokenHandler().WriteToken(access_Token);
        }
    }
}