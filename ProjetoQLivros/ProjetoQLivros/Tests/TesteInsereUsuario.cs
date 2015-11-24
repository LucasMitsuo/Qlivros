using ProjetoQLivros.Models.TabModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoQLivros.Tests
{
    public class TesteInsereUsuario
    {
        static void Main(string[] args)
        {
                
            QLivrosEntities db = new QLivrosEntities();

            var leitor = new TabLeitor();
            leitor.idLeitor = 7;
            leitor.dsEmail = "vmsilva19@gmail.com";
            leitor.dsLogin = "vmsilva";
            leitor.dsSenha = "1234";
            leitor.nmLeitor = "Vinicius Miranda da Silva";
            leitor.dsSexo = EnumSexoLeitor.MASCULINO.ToString();
            leitor.dtNasc = DateTime.Now;
            leitor.numCel = "119999-9999";
            leitor.dsRgLeitor = "45599991-2";
            leitor.noEnd = 133;
            leitor.dsComplementoEnd = "";
            leitor.dsReferenciaEnd = "";
            leitor.imFoto = "";
            leitor.fkIdCepEnd = 33495270;
            leitor.dsStatus =  1;

            db.TabLeitor.Add(leitor);
            db.SaveChanges();

        }


    }
 }   