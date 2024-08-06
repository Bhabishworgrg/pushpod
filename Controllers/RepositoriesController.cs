using Microsoft.AspNetCore.Mvc;
using pushpod.Data;

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
}
