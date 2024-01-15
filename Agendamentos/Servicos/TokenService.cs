using Agendamentos.Data;
using Agendamentos.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Agendamentos.Servicos;

public static class TokenService
{
    public static string GerarToken(DtoLogin usuario)
    {
        var tokenManipulador = new JwtSecurityTokenHandler();
        var chave = Encoding.ASCII.GetBytes(Settings.ChaveSecreta);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, usuario.Username.ToString()),
                new Claim(ClaimTypes.Name, usuario.Tipo.ToString()),
            }),

            Expires = DateTime.UtcNow.AddHours(2),

			SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(chave),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
        var token = tokenManipulador.CreateToken(tokenDescriptor);
        return tokenManipulador.WriteToken(token);
    }

	internal static object GerarToken(Usuario user)
	{
		throw new NotImplementedException();
	}
}
