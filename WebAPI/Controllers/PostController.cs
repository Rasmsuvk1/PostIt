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
    public async Task<ActionResult<Post>> CreatePostAsync(PostCreationDto dto)
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
    
    [HttpPut]
    public async Task<ActionResult<Comment>> AddCommentToPostAsync(CommentDto dto)
    {
        try
        {
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
   public async Task<ActionResult<ICollection<Post>>> GetAllPosts([FromQuery]int? id)
   {
       GetPostDto dto = new GetPostDto();
       dto.SetId(id);
        try
        {
            ICollection<Post> allPosts = await postLogic.GetAllPosts(dto);
            return Ok(allPosts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return StatusCode(500, e.Message);
        }
        
    }

}