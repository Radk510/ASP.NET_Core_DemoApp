using Client_Side.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client_Side.Services
{
    public class NoteService : INoteService
    {
        private readonly IHttpClientFactory _clientFactory;

        public NoteService(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// GET ALL NOTES
        /// </summary>
        /// <returns>All notes in db</returns>
        public async Task<List<Note>> GetNotes()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"{Configuration["WebApiUrl"]}api/notes");

            var client = _clientFactory.CreateClient();


            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var notes = await response.Content.ReadFromJsonAsync<List<Note>>();

                return notes;
            }
            else
            {
                throw new Exception("Error when get Notes");
            }

            //try
            //{
            //    var notes = await client.GetFromJsonAsync<List<Note>>($"{Configuration["WebApiUrl"]}api/notes");

            //    return notes;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error when get Notes", ex);
            //}
        }

        /// <summary>
        /// GET NOTE BY ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Specified note by id</returns>
        public async Task<Note> GetNote(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{Configuration["WebApiUrl"]}api/notes/{id}");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var note = await response.Content.ReadFromJsonAsync<Note>();

                return note;
            }
            else
            {
                throw new Exception("Error whe get Note by id");
            }

        }

        public async Task PostNote(Note note)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{Configuration["WebApiUrl"]}api/notes");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error to post note");
            }

        }
    }
}
