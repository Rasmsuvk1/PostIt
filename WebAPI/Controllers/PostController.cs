using Application.ILogic;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Domain.DTOs;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]

public class PostController: ControllerBase
{
    private readonly IPostLogic postLogic;

    public PostController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Post>> CreatePostAsync( PostCreationDto dto)
    {
        try
        {
            Post created = await postLogic.CreateAsync(dto);
            return Created($"/post/{created.Title}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
    }
}