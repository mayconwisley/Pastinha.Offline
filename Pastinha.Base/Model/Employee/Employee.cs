namespace Pastinha.Base.Model.Employee;

public class Employee
{
	public int Id { get; private set; }
	public int NumEmp { get; private set; }
	public int TipCol { get; private set; }
	public int NumCad { get; private set; }
	public int SitAfa { get; private set; }
	public string? NomFun { get; private set; } = string.Empty;

	protected Employee() { }

	public Employee(int numEmp, int tipCol, int numCad, int sitAfa, string? nomFun)
	{
		NumEmp = numEmp;
		TipCol = tipCol;
		NumCad = numCad;
		SitAfa = sitAfa;
		NomFun = nomFun;
	}
}
