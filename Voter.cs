using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Assignment_1
{
    internal class Voter
    {
        private string voterName;
        private string cnic;
        private string selectedPartyName;
        public Voter(string voterName, string cnic, string selectedPartyName = null)
        {
            this.voterName = voterName;
            this.cnic = cnic;
            this.selectedPartyName = selectedPartyName;
        }
        public Voter()
        {
            this.voterName = string.Empty;
            this.cnic = string.Empty;
            this.selectedPartyName = string.Empty;
        }
        public string VoterName
        {
            get { return voterName; }
        }
        public string CNIC
        {
            get { return cnic; }
            set { cnic = value; }
        }
        public string SelectedPartyName
        {
            get { return selectedPartyName; }
        }
        public bool hasVoted(string cnic)
        {
            string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = $"select * from Voter where VoterID='{cnic}'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if ("reader[2]"=="")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return $"Name: {voterName}, CNIC: {cnic}, PartyName: {selectedPartyName}";
        }
    }
}
