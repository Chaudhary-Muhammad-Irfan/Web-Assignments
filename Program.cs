using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Web_Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------Welcome To Online Voting System-------------------------");
            Console.WriteLine("1.        Add Voter");
            Console.WriteLine("2.        Update Voter");
            Console.WriteLine("3.        Delete Voter");
            Console.WriteLine("4.        Display Voters");
            Console.WriteLine("5.        Cast Vote");
            Console.WriteLine("6.        Insert Candidate");
            Console.WriteLine("7.        Update Candidate");
            Console.WriteLine("8.        Display Candidates");
            Console.WriteLine("9.        Delete Candidates");
            Console.WriteLine("10.       Declare Winner");
            Console.WriteLine("11.       Read Candidate");
            int num;
            Console.WriteLine("Enter your choice from 1 to 11: Enter -1 to Exit ");
            num = int.Parse(Console.ReadLine());
            while (num!=-1)
            {
                VotingMachine vm = new VotingMachine();
                Candidate candidate1 = new Candidate();
                Voter voter1 = new Voter();
                if (num == 1)
                {
                    vm.addVoter();
                }
                else if (num == 2)
                {
                    string id;
                    Console.WriteLine("Enter the ID of Voter whose data u want to update:");
                    id = Console.ReadLine();
                    vm.updateVoter(id);
                }
                else if (num == 3)
                {
                    string id;
                    Console.WriteLine("Enter the ID of Voter whose details u want to delete :");
                    id = Console.ReadLine();
                    vm.deleteVoter(id);
                }
                else if (num == 4)
                {
                    Console.WriteLine("Details of All Voters are Here:");
                    vm.displayVoters();
                }
                else if (num == 5)
                {
                    string cnic;
                    Console.WriteLine("Enter the CNIC of Voter :");
                    cnic=Console.ReadLine();
                    voter1.CNIC = cnic;
                    vm.castVote(voter1);
                }
                else if (num == 6)
                {
                    Console.WriteLine("---------------Enter The Details of Candidate---------------");
                    Console.WriteLine("Enter the Name of Candidate");
                    string candidateName = Console.ReadLine();
                    Console.WriteLine("Enter the Name of your Party");
                    string partyName = Console.ReadLine();
                    Candidate candidate = new Candidate(candidateName, partyName);
                    vm.insertCandidate(candidate);
                }
                else if (num == 7)
                {
                    int id;
                    Console.WriteLine("Enter ID of candidate whose record u want to update:");
                    id = int.Parse(Console.ReadLine());
                    vm.updateCandidate(id);
                }
                else if (num == 8)
                {
                    Console.WriteLine("Details of All Candidates are Here: ");
                    vm.displayCandidates();
                }
                else if (num == 9)
                {
                    int id;
                    Console.WriteLine("Enter the id of the candidate whose record u want to delete:");
                    id = int.Parse(Console.ReadLine());
                    vm.deleteCandidate(id);
                }
                else if (num == 10)
                {
                    Console.WriteLine("The Details of Winner Candidates are Here : ");
                    vm.DeclareWinner();
                }
                else if (num == 11)
                {
                    int id;
                    Console.WriteLine("Enter the ID of candidate Whose data u want to see: ");
                    id = int.Parse(Console.ReadLine());
                    vm.readCandidate(id);
                }
                else
                {
                    Console.WriteLine("Number is out of bound: ");
                }
                Console.WriteLine("-------------------------Welcome To Online Voting System-------------------------");
                Console.WriteLine("1.        Add Voter");
                Console.WriteLine("2.        Update Voter");
                Console.WriteLine("3.        Delete Voter");
                Console.WriteLine("4.        Display Voters");
                Console.WriteLine("5.        Cast Vote");
                Console.WriteLine("6.        Insert Candidate");
                Console.WriteLine("7.        Update Candidate");
                Console.WriteLine("8.        Display Candidates");
                Console.WriteLine("9.        Delete Candidates");
                Console.WriteLine("10.       Declare Winner");
                Console.WriteLine("11.       Read Candidate");
                Console.WriteLine("Enter your choice from 1 to 11: Enter -1 to Exit ");
                num = int.Parse(Console.ReadLine());
            }
        }
    }
}
