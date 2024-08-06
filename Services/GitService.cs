namespace pushpod.Services;

public class GitService
{
	private readonly string _repositoryDirectoryPath;

	public GitService(IWebHostEnvironment env)
	{
		_repositoryDirectoryPath = Path.Combine(env.ContentRootPath, "Repositories");
		Directory.CreateDirectory(_repositoryDirectoryPath);
	}

	public void CreateRepository(string name)
	{
		string repositoryPath = Path.Combine(_repositoryDirectoryPath, name);
		LibGit2Sharp.Repository.Init(repositoryPath, true);
	}

	public IEnumerable<string?> GetRepositories()
	{
		return Directory.GetDirectories(_repositoryDirectoryPath).Select(Path.GetFileName);
	}
}
