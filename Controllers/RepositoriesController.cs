using Microsoft.AspNetCore.Mvc;
using pushpod.Data;
using pushpod.Models;

namespace pushpod.Controllers;

public class RepositoriesController : Controller
{
	private readonly PushPodDbContext _context;

	public RepositoriesController(PushPodDbContext context)
	{
		_context = context;
	}

	// GET: /Repositories
	public IActionResult Index()
	{
		return View(_context.Repositories.ToList());
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
			return RedirectToAction(nameof(Index));
		}
		return View(repository);
	}
}
