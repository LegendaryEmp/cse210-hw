using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video firstVideo = new Video("How to Make Sourdough Bread", "Kitchen Basics", 845);
        firstVideo.AddComment(new Comment("Maria", "The starter tips were very helpful."));
        firstVideo.AddComment(new Comment("James", "I tried this recipe and it turned out great."));
        firstVideo.AddComment(new Comment("Priya", "Could you make a video about whole wheat bread?"));

        Video secondVideo = new Video("Beginner Guitar Chords", "Music Room", 612);
        secondVideo.AddComment(new Comment("Tyler", "This made the chord changes much easier."));
        secondVideo.AddComment(new Comment("Anna", "I appreciate the slow demonstrations."));
        secondVideo.AddComment(new Comment("Devin", "The practice exercise at the end is excellent."));

        Video thirdVideo = new Video("A Tour of the Solar System", "Science Explained", 934);
        thirdVideo.AddComment(new Comment("Liam", "The scale comparisons are fascinating."));
        thirdVideo.AddComment(new Comment("Noah", "Saturn has always been my favorite planet."));
        thirdVideo.AddComment(new Comment("Chloe", "This was perfect for my science project."));

        Video fourthVideo = new Video("Organizing a Small Workspace", "Simple Spaces", 487);
        fourthVideo.AddComment(new Comment("Grace", "The cable management idea is clever."));
        fourthVideo.AddComment(new Comment("Ethan", "My desk looks much better now."));
        fourthVideo.AddComment(new Comment("Zoe", "I would love more videos for small apartments."));

        List<Video> videos = new List<Video>
        {
            firstVideo,
            secondVideo,
            thirdVideo,
            fourthVideo
        };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
