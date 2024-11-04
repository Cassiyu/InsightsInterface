using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly IFeedbackRepository _feedbackRepository;

    public FeedbackController(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Get() => Ok(await _feedbackRepository.GetAllAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(string id)
    {
        var feedback = await _feedbackRepository.GetByIdAsync(id);
        if (feedback == null) return NotFound();
        return Ok(feedback);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create(Feedback feedback)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _feedbackRepository.CreateAsync(feedback);
        return CreatedAtAction(nameof(GetById), new { id = feedback.Id }, feedback);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(string id, Feedback feedback)
    {
        var existingFeedback = await _feedbackRepository.GetByIdAsync(id);
        if (existingFeedback == null) return NotFound();

        feedback.Id = id;
        await _feedbackRepository.UpdateAsync(id, feedback);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(string id)
    {
        var feedback = await _feedbackRepository.GetByIdAsync(id);
        if (feedback == null) return NotFound();

        await _feedbackRepository.DeleteAsync(id);
        return NoContent();
    }
}
