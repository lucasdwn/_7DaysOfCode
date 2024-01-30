using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _7DaysOfCode.Models;
using _7DaysOfCode.Services;

namespace _7DaysOfCode.Controllers
{
    public class MascoteController
    {
        private string urlBase = "https://pokeapi.co/api/v2/pokemon/";
        private List<Mascote> _mascotes;

        public void VisualizarMascotes()
        {
            List<Mascote> mascotes = GetApiData<MascoteListResponse>(urlBase).Results;
            if (mascotes != null)
            {
                Console.WriteLine("Mascotes disponiveis:");
                foreach (var mascote in mascotes)
                {
                    Console.WriteLine($"Nome: {mascote.Nome}, Url: {mascote.Url}");
                }
                _mascotes = mascotes;
            }
        }
        public void VisualizarHabilidades()
        {
            Console.WriteLine("Qual mascote você deseja visualizar as habilidades?");
            string mascoteNome = Console.ReadLine();
            Mascote mascoteEscolhido = new Mascote();

            if (_mascotes == null)
                mascoteEscolhido = GetApiData<MascoteListResponse>(urlBase).Results.Where(x => x.Nome == mascoteNome).First();
            else
                mascoteEscolhido = _mascotes.Where(x => x.Nome == mascoteNome).First();

            string mascoteUrl = mascoteEscolhido.Url;
            if (mascoteUrl != "")
            {
                List<HabilideInfo> habilidades = GetApiData<MascoteListResponse>(mascoteUrl).Habilidades;
                if (habilidades != null)
                {
                    mascoteEscolhido.habilidades = habilidades;
                    Console.Clear();
                    Console.WriteLine($"Mascote escolhido: {mascoteEscolhido.Nome}");
                    Console.WriteLine($"Habilidades:");
                    foreach (var habilidade in mascoteEscolhido.habilidades)
                    {
                        Console.WriteLine($"Nome: {habilidade.Habilidade.Nome}, Url: {habilidade.Habilidade.Url}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Mascote invalido");
            }

        }
        static T GetApiData<T>(string apiUrl)
        {
            return ApiService.Get<T>(apiUrl);
        }
    }
}