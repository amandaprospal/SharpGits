namespace SharpGits.Console.Data;

public class Database
{
    public static void Init(string workspacePath)
    {
	    var gitDirPath = Path.Combine(workspacePath, ".git");

	    if (Directory.Exists(gitDirPath))
	    {
		    return;
	    }

		CreateInitDirs(gitDirPath);
    }

    private static void CreateInitDirs(string gitDirPath)
    {
	    Directory.CreateDirectory(gitDirPath);
		Directory.CreateDirectory(Path.Combine(gitDirPath, "objects"));
	    Directory.CreateDirectory(Path.Combine(gitDirPath, "refs"));
	}
}