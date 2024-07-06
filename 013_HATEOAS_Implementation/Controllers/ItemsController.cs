using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _013_HATEOAS_Implementation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private static List<Item> items = new List<Item>
        {
            new Item { Id = 1, Name = "Item 1" },
            new Item { Id = 2, Name = "Item 2" }
        };

        [HttpGet("{id}", Name = "GetItem")]
        public IActionResult GetItem(int id)
        {
            var item = items.Find(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            var response = new ItemResponse
            {
                Id = item.Id,
                Name = item.Name,
                Links = new List<Link>
                {
                    new Link(Url.Link("GetItem", new { id }), "self", "GET"),
                    new Link(Url.Link("UpdateItem", new { id }), "update_item", "PUT"),
                    new Link(Url.Link("DeleteItem", new { id }), "delete_item", "DELETE")
                }
            };

            return Ok(response);
        }

        [HttpPut("{id}", Name = "UpdateItem")]
        public IActionResult UpdateItem(int id, [FromBody] Item updatedItem)
        {
            var item = items.Find(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            item.Name = updatedItem.Name;
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteItem")]
        public IActionResult DeleteItem(int id)
        {
            var item = items.Find(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            items.Remove(item);
            return NoContent();
        }
    }

    public class Link
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }

        public Link(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }

    public class ItemResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Link> Links { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
