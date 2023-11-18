using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Category
{
    private string name;
    private List<JobOffer> offers;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            if(value.Length >= 2 && value.Length <= 40)
            {
                name = value;
            }
            else
            {
                throw new ArgumentException($"{nameof(Name)} should be between 2 and 40 characters!");
            }
            
        }
    }

    public Category(string name)
    {
        Name = name;
        offers = new List<JobOffer>();
    }

    public void AddJobOffer(JobOffer offer)
    {
        offers.Add(offer);
    }

    public double AverageSalary()
    {
        if(offers.Count == 0)
        {
            return 0;
        } else
        {
            return offers.Average(offers => offers.Salary);
        }
    }

    public List<JobOffer> GetOffersAboveSalary(double salary)
    {
        return offers.Where(offers => offers.Salary >= salary)
            .OrderByDescending(offers => offers.Salary).ToList();

    }

    public List<JobOffer> GetOffersWithoutSalary()
    {
        return offers.Where(offers => offers.Salary == 0).OrderBy(offers => offers.Company).ToList();
    }

    public override string ToString()
    {
        return $"Category: {nameof(Name)}" + $"{Environment.NewLine}" + $"Total Offers: {offers.Count}";
    }
}