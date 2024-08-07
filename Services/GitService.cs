namespace pushpod.Services;

public class GitService
{
	public string RepositoryDirectoryPath { get; }

	public GitService(IWebHostEnvironment env)
	{
		RepositoryDirectoryPath = Path.Combine(env.ContentRootPath, "Repositories");
		Directory.CreateDirectory(RepositoryDirectoryPath);
	}

	public void CreateRepository(string name)
	{
		string repositoryPath = Path.Combine(RepositoryDirectoryPath, name);
		LibGit2Sharp.Repository.Init(repositoryPath, true);
	}

	public IEnumerable<string?> GetRepositories()
	{
		return Directory.GetDirectories(RepositoryDirectoryPath).Select(Path.GetFileName);
	}
}
