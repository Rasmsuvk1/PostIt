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
    public async Task<ActionResult<Post>> CreatePostAsync([FromQuery] string? username, [FromQuery] string? title, [FromQuery] string? body)
    {
        try
        {
            PostCreationDto dto = new PostCreationDto(username, title, body);
            Post created = await postLogic.CreateAsync(dto);
            return Created($"/post/{created.Title}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPut]
    public async Task<ActionResult<Comment>> AddCommentToPostAsync([FromQuery] string? postname, [FromQuery] string? username, [FromQuery] string? text)
    {
        try
        {
            CommentDto dto = new CommentDto(postname, username, text);
            Comment created = await postLogic.AddCommentAsync(dto);
            return Created($"/post/{created.text}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete]
    public async Task<ActionResult> DeletePostAsync(string postToDelete)
    {
        try
        {
            Post created = await postLogic.DeleteAsync(postToDelete);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
   public async Task<ActionResult<ICollection<Post>>> GetAllPosts()
    {
        try
        {
            ICollection<Post> allPosts = await postLogic.GetAllPosts();
            return Ok(allPosts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
        
    }

}