using Microsoft.AspNetCore.Mvc;
using pushpod.Services;

namespace pushpod.Controllers;

[Route("{repositoryName}")]
public class GitController : Controller
{
	private readonly GitService _gitService;

	public GitController(GitService gitService)
	{
		_gitService = gitService;
	}

	[HttpGet("info/refs")]
	public IActionResult InfoRefs(string repositoryName, [FromQuery] string service)
	{
		string repositoryPath = Path.Combine(_gitService.RepositoryDirectoryPath, repositoryName);
		if (!Directory.Exists(repositoryPath))
		{
			return NotFound();
		}

		if (service != "git-upload-pack")
		{
			return BadRequest();
		}

		return Content($"The git repository for {repositoryName} is available.");
	}

	[HttpPost("git-upload-pack")]
	public IActionResult GitUploadPack(string repositoryName)
	{
		string repositoryPath = Path.Combine(_gitService.RepositoryDirectoryPath, repositoryName);
		if (!Directory.Exists(repositoryPath))
		{
			return NotFound();
		}
		return Content($"The git repository for {repositoryName} is available.");
	}
}
