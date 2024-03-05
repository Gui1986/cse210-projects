using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating job instances
        Job job1 = new Job("Software Engineer", "Microsoft", "2019-2022");
        Job job2 = new Job("Manager", "Apple", "2022-2023");

        // Displaying company of job1 and job2
        Console.WriteLine(job1._company);
        Console.WriteLine(job2._company);

        // Adding Display method to Job class and displaying job details
        job1.Display();
        job2.Display();

        // Creating resume instance
        Resume myResume = new Resume("Allison Rose");

        // Adding jobs to the resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Accessing and displaying the first job title
        Console.WriteLine(myResume._jobs[0]._jobTitle);

        // Adding Display method to Resume class and displaying resume details
        myResume.Display();
    }
}
