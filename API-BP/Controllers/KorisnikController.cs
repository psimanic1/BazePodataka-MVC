using Model_BP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using System.Xml.Serialization;
using API_BP.Controllers;
using Data_BP;

namespace API_BP.Controllers
{
    [RoutePrefix("api/Korisnik")]
    public class KorisnikController : ApiController
    {
        [AcceptVerbs("POST","GET")]
        [Route("Register")]
        public bool Register(KorisnikDTO kor)
        {
            using (var ctx = new RentacarEntities())
            {
                var k = ctx.Korisnik.FirstOrDefault(u => u.Username == kor.UsernameDTO);

                if (k != null)
                {
                    throw new Exception("Exception");
                }

                k = new Korisnik()
                {
                    IDKorisnika = kor.IDKorisnikaDTO,
                    Username = kor.UsernameDTO,
                    Ime = kor.ImeDTO,
                    Prezime = kor.PrezimeDTO,
                    BrojTelefona = kor.BrojTelefonaDTO,
                    Adresa = kor.AdresaDTO,
                    Sifra = HashClass.Encrypt(kor.SifraDTO)
                };

                ctx.Korisnik.Add(k);
                ctx.SaveChanges();
                return true;
            }
        }

        [AcceptVerbs("POST", "GET")]
        [Route("Login")]
        public KorisnikDTO Login(KorisnikDTO kor)
        {
            string pass = HashClass.Encrypt(kor.SifraDTO);
            var ctx = new RentacarEntities();
            var k = ctx.Korisnik.FirstOrDefault(u => (u.Username.TrimEnd() == kor.UsernameDTO.TrimEnd()) && u.Sifra == pass);

            if (k == null) return null;

            var korisnik = new KorisnikDTO()
            {
                UsernameDTO = k.Username,
                ImeDTO = k.Ime
            };
            return korisnik;
        }

        [AcceptVerbs("POST", "GET")]
        [Route("Obrisi")]
        public bool Obrisi(KorisnikDTO kor)
        {
            var ctx = new RentacarEntities();
            var k = ctx.Korisnik.FirstOrDefault(u => (u.Username.TrimEnd() == kor.UsernameDTO.TrimEnd()));

            if (k == null) return false;

            ctx.Korisnik.Remove(k);
            ctx.SaveChanges();
            return true;
        }
    }

    public class HashClass
    {
        public static string Encrypt(string pass)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(pass);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] password = sha.ComputeHash(bytes);

            string result = System.Text.Encoding.UTF8.GetString(password);

            return result;
        }

    }
}