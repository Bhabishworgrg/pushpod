using Microsoft.AspNetCore.Mvc;
using pushpod.Data;
using pushpod.Models;
using pushpod.Services;

namespace pushpod.Controllers;

public class RepositoriesController : Controller
{
	private readonly PushPodDbContext _context;
	private readonly GitService _gitService;

	public RepositoriesController(PushPodDbContext context, GitService gitService)
	{
		_context = context;
		_gitService = gitService;
	}

	// GET: /Repositories
	public IActionResult Index()
	{
		List<Repository> repositories = _context.Repositories.ToList();
		return View(repositories);
	}

	// GET: /Repositories/Create
	public IActionResult Create()
	{
		return View();
	}

	// POST: /Repositories/Create
	[HttpPost]
	public IActionResult Create(Repository repository)
	{
		if (ModelState.IsValid)
		{
			_context.Repositories.Add(repository);
			_context.SaveChanges();
			_gitService.CreateRepository(repository.Name);
			return RedirectToAction(nameof(Index));
		}
		return View(repository);
	}
}
