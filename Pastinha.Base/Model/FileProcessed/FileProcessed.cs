namespace Pastinha.Base.Model.FileProcessed;

public class FileProcessed
{
	public int Id { get; private set; }
	public int NumEmp { get; private set; }
	public int TipCol { get; private set; }
	public int NumCad { get; private set; }
	public int AmountProcessed { get; private set; }
	public string NomDoc { get; private set; } = string.Empty;
	public DateOnly DateProcessed { get; private set; }

	protected FileProcessed() { }

	public FileProcessed(int numEmp, int tipCol, int numCad, int amountProcessed, string nomDoc, DateOnly dateProcessed)
	{
		NumEmp = numEmp;
		TipCol = tipCol;
		NumCad = numCad;
		AmountProcessed = amountProcessed;
		NomDoc = nomDoc;
		DateProcessed = dateProcessed;
	}

	public void SetAmount(int amaout)
	{
		AmountProcessed += amaout;
	}
}
