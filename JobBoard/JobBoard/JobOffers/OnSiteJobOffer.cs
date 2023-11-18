using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.JobOffers
{
    public class OnSiteJobOffer : JobOffer
    {


        public OnSiteJobOffer(string jobTitle, string company, float salary, string city) : base(jobTitle, company, salary)
        {
            City = city;
        }


        private string city;

        public string City
        {
            get { return city; }
            set
            {
                if (value.Length >= 3 && value.Length <= 30)
                {
                    city = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(City)} should be between 3 and 30 characters!");
                }
            }

        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine($"City: {City}");

            return builder.ToString().Trim();
        }


    }
}
