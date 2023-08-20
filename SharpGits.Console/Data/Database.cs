using System.Text;

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
		CreateHeadFile(gitDirPath);
    }

    private static void CreateInitDirs(string gitDirPath)
    {
	    Directory.CreateDirectory(gitDirPath);
		Directory.CreateDirectory(Path.Combine(gitDirPath, "objects"));
	    Directory.CreateDirectory(Path.Combine(gitDirPath, "refs"));
	}

    private static void CreateHeadFile(string gitDirPath)
    {
	    var filePath = Path.Combine(gitDirPath, "HEAD");
	    using var fs = File.Create(filePath);
	    var fileContents = new UTF8Encoding(true).GetBytes("ref: refs/heads/main\n");
	    fs.Write(fileContents, 0, fileContents.Length);
    }
}