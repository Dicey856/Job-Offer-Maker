
using System.Text;
public abstract class JobOffer
{
    private string jobTitle;

    private string company;

    private float salary;

    public JobOffer (string jobTitle, string company, float salary)
    {
        JobTitle = jobTitle;
        Company = company;
        Salary = salary;
    }




    public string JobTitle
    {
        get { return jobTitle; } 
        set {
            if(value.Length >= 3 && value.Length <= 30)
            {
                jobTitle = value;
            }
            else
            {
                throw new ArgumentException($"{nameof(JobTitle)} should be between 3 and 30 characters!");
            }
        }
    }

    public string Company
    {
        get { return company; }
        set
        {
            if (value.Length >= 3 && value.Length <= 30)
            {
                company = value;
            }
            else
            {
                throw new ArgumentException($"{nameof(Company)} should be between 3 and 30 characters!");
            }
        }
    }

    public float Salary
    {
        get { return salary; }
        set
        {
            if(value < 0)
            {
                throw new ArgumentException($"{Salary} should be 0 or positive!");
            } else
            {
                salary = value;
            }
        }
    }


    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Job Title: {JobTitle}");
        builder.AppendLine($"Company: {Company}");
        builder.AppendLine($"Salary: {Salary:F2} BGN");

        return builder.ToString();
    }

}