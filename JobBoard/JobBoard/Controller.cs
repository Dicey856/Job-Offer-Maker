using JobBoard.JobOffers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;


public class Controller
{
    private readonly Dictionary<string, Category> categories;

    public Controller()
    {
        categories = new Dictionary<string, Category>();
    }

    public string AddCategory(List<string> args)
    {
        string name = args[0];
        Category category = new Category(name);
        categories[name] = category;

        return $"Created Category {name}!";
    }

    public string AddJobOffer(List<string> args)
    {
        string categoryName = args[0];
        string jobTitle = args[1];
        string company = args[2];
        float salary = float.Parse(args[3]);
        string type = args[4];

        JobOffer offer = null;

        if(type == "onsite")
        {
            string city = args[5];
            offer = new OnSiteJobOffer(jobTitle, company, salary, city);
        }
        else
        {
            bool fullyRemote = bool.Parse(args[5]);
            offer = new RemoteJobOffer(jobTitle, company, salary, fullyRemote);
        }

        Category category = categories[categoryName];
        category.AddJobOffer(offer);

        return $"Created JobOffer {jobTitle} in Category {categoryName}!";

    }

    public string GetAverageSalary(List<string> args)
    {
        string catname = args[0];
        Category category = categories[catname];
        double avrsalary = category.AverageSalary();

        return $"The average salary is: {avrsalary:F2} BGN";
    }

    public string GetOffersAboveSalary(List<string> args)
    {
        string catname = args[0];
        float salary = float.Parse(args[1]);
        
        Category category = categories[catname];
        List<JobOffer> Resultoffers = category.GetOffersAboveSalary(salary);
        
        StringBuilder builder = new StringBuilder();
        Resultoffers.ForEach(offer =>  builder.Append(offer.ToString()));
        
        return builder.ToString().Trim();

    }

    public string GetOffersWithoutSalary(List<string> args)
    {
        string catname = args[0];
        Category category = categories[catname];

        List<JobOffer> NoSalaryOffers = category.GetOffersWithoutSalary();

        StringBuilder builder = new StringBuilder();

        NoSalaryOffers.ForEach(offer => builder.Append(offer.ToString()));

        return builder.ToString().Trim();   
    }

}