using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Data.SqlClient;
using System.Xml.XPath;
using System.Collections;
namespace Web_Assignment_1
{
    internal class VotingMachine
    {
        private List<Candidate> candidates = new List<Candidate>();
        public VotingMachine()
        {
            candidates = new List<Candidate>();
        }
        public void castVote(Voter v)
        {
            if (v.hasVoted(v.CNIC))
            {
                Console.WriteLine("The voter has already voted:");
            }
            else
            {
                Console.WriteLine("Enter the ID of the Candidate from the Given IDs to Vote for:  ");
                displayCandidateIDs();
                int id=int.Parse(Console.ReadLine());
                try
                {
                    string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                    SqlConnection con = new SqlConnection(connection);
                    con.Open();
                    string query1 = $"update Voter set SelectedPartyName=(select Party from Candidate where CandidateID={id})";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    string query2 = $"update Candidate set Votes=Votes+1 where CandidateID={id}";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    Console.WriteLine("Voter voted successfully:");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void addVoter()
        {
            Console.WriteLine("---------------Enter Voter Details:---------------");
            string name;
            Console.Write("Name :   ");
            name = Console.ReadLine();
            string idNumber;
            Console.Write("CNIC :   ");
            idNumber = Console.ReadLine();
            string partyName=string.Empty;
            Voter v = new Voter(name, idNumber, partyName);
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                string query = $"insert into Voter(VoterName,VoterID,SelectedPartyName) values ('{name}','{idNumber}','{partyName}')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                string jsonString = JsonSerializer.Serialize(v);
                StreamWriter write = new StreamWriter("voter.txt", append: true);
                write.WriteLine(jsonString);
                write.Close();
                Console.WriteLine("Voter has been added Successfully To both File and Database");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void updateVoter(string cnic)
        {
            string name, party;
            Console.WriteLine("Enter new name of Voter:");
            name = Console.ReadLine();
            Console.WriteLine("Enter new Party of Voter:");
            party = Console.ReadLine();
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                string query = $"update Voter set VoterName='{name}', SelectedPartyName='{party}' where VoterID='{cnic}'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery ();
                con.Close();
                Console.WriteLine("Voter has been updated Successfully:");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void displayVoters()
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                string query = $"Select * from Voter";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("ID of Voter is : " + reader[0]);
                    Console.WriteLine("Name of Voter is :" + reader[1]);
                    Console.WriteLine("Party of Voter is :" + reader[2]);
                    Console.WriteLine("-------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void displayCandidateIDs()
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                string query = $"Select * from Candidate";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("ID : " + reader[0]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void displayCandidates()
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                string query = $"Select * from Candidate";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Name of Candidate is :" + reader[0]);
                    Console.WriteLine("ID of Candidate is : " + reader[1]);
                    Console.WriteLine("Party of Candidate is :" + reader[2]);
                    Console.WriteLine("Votes of Candidate are :" + reader[3]);
                    Console.WriteLine("-------------------------------------------");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeclareWinner()
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                string query = $"select * from Candidate where Votes=(select max(Votes) from Candidate)";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("The Name is : " + reader[1]);
                    Console.WriteLine("The ID is : " + reader[0]);
                    Console.WriteLine("The votes are : " + reader[3]);
                    Console.WriteLine("The Party is : " + reader[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void insertCandidate(Candidate c)
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                string query = $"insert into Candidate values ({c.CandidateID},'{c.Name}','{c.Party}',{c.Votes})";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                string jsonString = JsonSerializer.Serialize(c);
                StreamWriter sw = new StreamWriter("candidate.txt", append: true);
                sw.WriteLine(jsonString);
                sw.Close();
                candidates.Add(c);
                Console.WriteLine("Candidate has been inserted successfully to both File and Database:");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void readCandidate(int id)
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                string query = $"select * from Candidate where CandidateID={id}";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine("Details of Candidate Are:");
                    Console.WriteLine("Name of Candidate is :" + reader[1]);
                    Console.WriteLine("ID of Candidate is : " + reader[0]);
                    Console.WriteLine("Party of Candidate is :" + reader[2]);
                    Console.WriteLine("Votes of Candidate are :" + reader[3]);
                }
                else
                {
                    Console.WriteLine("Data Not Found:");
                }
                con.Close() ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void updateCandidate(int id)
        {
            string name, party;
            Console.WriteLine("Enter new name of Candidate:");
            name = Console.ReadLine();
            Console.WriteLine("Enter new Party of Candidate:");
            party = Console.ReadLine();
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                string query = $"update Candidate set Name='{name}',Party='{party}' where CandidateID={id}";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("The record of Candidate has been Updated:");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void deleteCandidate(int id)
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                string query = $"delete Candidate where CandidateID={id}";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Candidate has been deleted Successfully:");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void deleteVoter(string id)
        {
            try
            {
                string connection = "Data Source=(localdb)\\ProjectModels;Initial Catalog=VotingSystem;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                string query = $"delete Voter where VoterID='{id}'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Voter has been deleted Successfully:");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
