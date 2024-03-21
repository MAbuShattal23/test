public class Department{
    public int Id {get; set;}
    public string? Name { get; set; } 
    public int MgrSSn { get; set; }
    public DateTime MgrStartDate { get; set; }
   
    public Department(int id, string name, int mgrSSn, DateTime mgrStartDate   ){
        this.Id = id;
        this.Name = name;
        this.MgrSSn = mgrSSn;
        this.MgrStartDate = mgrStartDate;       
     }
}