using Application.Interfaces;
using Application.Models.Requets;
using Domain.Entities;
using Domain.Exceptions;
using Domain.IRepository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace Infra.Service
{
    public class AutenticacionService : ICustomAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly AutenticacionServiceOptions _options;

        public AutenticacionService(IUserRepository userRepository, IOptions<AutenticacionServiceOptions> options)
        {
            _userRepository = userRepository;
            _options = options.Value;
        }

        private User ValidateUser(AuthenticationRequest authenticationRequest)
        {
            if ((string.IsNullOrEmpty(authenticationRequest.Email)) || (string.IsNullOrEmpty(authenticationRequest.Password)))
            {
                return null;
            }

            var user = _userRepository.GetByEmail(authenticationRequest.Email);
            if (user == null)
            {
                return null;
            }

            if (user.Email == authenticationRequest.Email && user.Password == authenticationRequest.Password)
            {
                return user;
            }
            return null;
        }

        public string Autenticar(AuthenticationRequest authenticationRequest)
        {
            var user = ValidateUser(authenticationRequest); //PRIMER PASO - EL CHOCLO DE ARRIBA

            if (user == null)
            {
                throw new NotAllowedException("La autenticación ha fallado");
            }

            //PASO DOS - CREAMO JWT CREAR TOKEN
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));
            //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens; 

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256); //hasheamos

            // los claims son como un diccionario en python, funcionan con clave/valor
            var claimsForToken = new List<Claim>();

            claimsForToken.Add(new Claim("sub", user.Id.ToString()));
            //sub es una key que es el identificar único del usuario (convención) 
            claimsForToken.Add(new Claim("email", user.Email.ToString()));
            //claimsForToken.Add(new Claim("bla", user.Password.ToString())); INFO SENSIBLE NO SE PUEDE MANDAR EN UN TOKEN - LAS CLAIMS NO ESTÁN HASHEADAS ESTÁN
            //CODIFICADO, LA FIRMA ES LO QUE ESTÁ HASHEADO. 
            /*Cualquiera que tiene el token puede verlo, pero dura un tiempo, por eso usamos las autenticación*/

            var jwtSecurityToken = new JwtSecurityToken(
                //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
                _options.Issuer,
                _options.Audience,
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                credentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);// pasamos el token a string

            return tokenToReturn.ToString();

        }

        public class AutenticacionServiceOptions
        {
            public const string AutenticacionService = "AutenticacionService";

            public string Issuer { get; set; }
            public string Audience { get; set; }
            public string SecretForKey { get; set; }
        }
    }
}
