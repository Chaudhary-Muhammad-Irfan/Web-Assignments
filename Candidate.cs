using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Assignment_1
{
    internal class Candidate
    {
        private int candidateID;
        private string name;
        private string party;
        private int votes;
        private int GenerateCandidateID()
        {
            Random rand = new Random();
            return candidateID = rand.Next(1, 10000);
        }
        public Candidate(string name, string party)
        {
            this.name = name;
            this.party = party;
            this.candidateID = GenerateCandidateID();
            this.votes = 0;
        }
        public Candidate()
        {
            this.name =string.Empty;
            this.party =string.Empty;
            this.candidateID=0;
            this.votes = 0;
        }
        public int CandidateID
        {
            get { return candidateID; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Party
        {
            get { return party; }
            set { party = value; }
        }
        public int Votes
        {
            get { return votes; }
        }
        public void incrementVotes()
        {
            votes = votes + 1;
        }
        public override string ToString()
        {
            return $"Party: {Party},Name: {Name}, CandidateID: {CandidateID}, Votes: {Votes} ";
        }
    }
}
