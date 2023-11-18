using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.JobOffers
{
    internal class RemoteJobOffer : JobOffer
    {
        

        public RemoteJobOffer(string jobTitle, string company, float salary, bool fullyRemote) : base(jobTitle, company, salary)
        {
            FullyRemote = fullyRemote;
        }

        public bool FullyRemote { get; private set; }

        public override string ToString()
        {
            
            StringBuilder builder = new StringBuilder();
            string fullyRemotestr = FullyRemote ? "yes" : "no";

            builder.AppendLine(base.ToString());
            builder.AppendLine($"Fully Remote: {fullyRemotestr}");



            return builder.ToString().Trim();
        }
    }
}
