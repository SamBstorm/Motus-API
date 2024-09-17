using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motus_DataAccessLayer.Services
{
    public class MotusService : BaseService, IMotusRepository
    {
        public MotusService(IConfiguration config) : base(config, "MiniLexique")
        {
        }

        public string GetRandomWord(int? wordSize)
        {
            string query ;
            Dictionary<string, object?> parameters = new Dictionary<string, object?>();
            if (wordSize is null)
            {
                query = "SP_Word_GetRandom";
            }
            else if (wordSize < 6 || wordSize > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(wordSize), "Les mots sont limité à une taille de 6 à 9 caractères.");
            }
            else
            {
                query = "SP_Word_GetRandom_W_Size";
                parameters.Add(nameof(wordSize), wordSize);
            }
            using (SqlCommand cmd = CreateCommand(query,true,parameters))
            {
                cmd.Connection.Open();
                return (string)cmd.ExecuteScalar();
            }
        }

        public bool IsValid(string word)
        {
            Dictionary<string, object?> parameters = new Dictionary<string, object?>();
            parameters.Add(nameof(word), word);
            using(SqlCommand cmd = CreateCommand("SP_Word_Check", true, parameters))
            {
                cmd.Connection.Open();
                return !(cmd.ExecuteScalar() is null);
            }
        }

    }
}
