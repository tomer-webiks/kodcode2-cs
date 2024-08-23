using IronDome.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IronDome.ViewModels
{
    public class AttackViewModel
    {

        public Attack? Attack { get; set; }

        public List<SelectListItem>? TypeSelectListItems { get; set; }
        public List<SelectListItem>? OriginSelectListItems { get; set; }
    }
}
