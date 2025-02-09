package Controller;

import Models.*;
import Service.OpenAIService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/content")
public class ContentController {

    @Autowired
    private OpenAIService openAIService;

    @PostMapping("/generate")
    public ContentResponse generateContent(@RequestBody ContentRequest request) {
        return openAIService.generateIdea(request.getTopic());
    }
}
