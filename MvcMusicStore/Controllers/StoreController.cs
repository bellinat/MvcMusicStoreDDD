using System.Web.Mvc;
using MvcMusicStore.Application.Interfaces;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly IGenreAppService _genreAppService;
        private readonly IAlbumAppService _albumAppService;
        private readonly IClientAppService _clientAppService;
        private readonly IUserAppService _userAppService;

        public StoreController(
            IGenreAppService genreAppService, 
            IAlbumAppService albumAppService, 
            IClientAppService clientAppService,
            IUserAppService userAppService)
        {
            _genreAppService = genreAppService;
            _albumAppService = albumAppService;
            _clientAppService = clientAppService;
            _userAppService = userAppService;
        }

        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = _genreAppService.All(@readonly: true);

            // TESTE PARA VERIFICAR O CONTEXTO StoreContext
            var clients = _clientAppService.All();

            // TESTE PARA VERIFICAR O CONTEXTO IdentityContext
            var users = _userAppService.All();

            return View(genres);
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = _genreAppService.GetWithAlbums(genre);

            return View(genreModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            var album = _albumAppService.Get(id, @readonly: true);

            return View(album);
        }

        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = _genreAppService.All(@readonly: true);

            return PartialView(genres);
        }

    }
}