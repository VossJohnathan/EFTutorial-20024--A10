using EFTutorial_20024.Models;

namespace EFTutorial_20024
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program starting...");

            
            Console.WriteLine("Enter your selection:");
            Console.WriteLine("You may need to wait a few seconds...");
            Console.WriteLine("1) Display all blogs");
            Console.WriteLine("2) Add or Update a Blog");
            Console.WriteLine("3) Display Post");
            Console.WriteLine("4) Add Post");
            Console.WriteLine("Enter q to quit.");
            var userInput = Console.ReadLine();

            if (userInput == "1")
            {
                // Display Blogs
                // C R U D
                // READ the Blogs
                using (var context = new BlogContext())
                {
                    var blogsList = context.Blogs.ToList();

                    Console.WriteLine("The blogs are:");
                    foreach (var blog in blogsList)
                    {
                        Console.WriteLine($"    {blog.Name}");
                    }
                    // Connection is automatically disposed at end of code block if Using() -- ((Line 12))
                }
                // This closes the connection to the database.
                // context.Dispose();

            }
            else if (userInput == "2")
            {

                Console.WriteLine("Would you like to update or add a blog?");
                Console.WriteLine("1) Add blog");
                Console.WriteLine("The following option is not part of the assignment");
                Console.WriteLine("Due to this, it has limited funtionality.");
                Console.WriteLine("2) Update a blog");
                var updateOrAdd = Console.ReadLine();

                if (updateOrAdd == "1")
                {
                    // Add Blogs
                    // C R U D
                    // Create a Blog
                    using (var context = new BlogContext())
                    {
                        Console.WriteLine("Enter a blog name");
                        var blogName = Console.ReadLine();

                        var blog = new Blog();
                        blog.Name = blogName;

                        context.Blogs.Add(blog);
                        context.SaveChanges();
                    }
                }
                else if (updateOrAdd == "2")
                {
                    // C R U D
                    // UPDATE the Blog
                    Console.WriteLine("This is not part of the assignment.");
                    Console.WriteLine("This will ONLY update the blog with ID of 1");
                    using (var context = new BlogContext())
                    {
                        var blogToUpdate = context.Blogs.Where(b => b.BlogId == 1).First();

                        Console.WriteLine($"Your choice is {blogToUpdate.Name}");
                        Console.WriteLine("What do you want the name to be?");
                        var updatedName = Console.ReadLine();

                        blogToUpdate.Name = updatedName;
                        context.SaveChanges();
                    }

                }

                // To remove
                //context.remove(Blogtoupdate);
                //context.SaveChanges();

            }
            else if (userInput == "3")
            {
                // Display Posts
                //READ the posts
                using (var context = new BlogContext())
                {

                    //Ask user which blog -- See option 2
                    Console.WriteLine("Which Blog would you like to look at?");
                    var userBlogPick = Convert.ToInt32(Console.ReadLine());


                    //var postsList = context.Posts.ToList();
                    //Is this scuffed, or did I do this right??
                    //I mean, hey it works!!
                    var postsList = context.Posts.Where(b => b.BlogId == userBlogPick).ToList();
                    //context.Blogs.Where(b => b.BlogId == userBlogPick)


                    Console.WriteLine("The posts are:");
                    //All posts related to that blog should be displayed
                    
                    foreach (var post in postsList) 
                    // Display Blog name, Post Title and Post Content.
                    {
                    
                            Console.WriteLine($"Blog: {post.Blog.Name}");
                            Console.WriteLine($"    {post.Title}");
                            Console.WriteLine($"    {post.Content}");
                        

                    }
                        
                }

            }
            else if (userInput == "4")
            {
                // Add Post
                //CREATE a Post
                using (var context = new BlogContext())
                {
                    //Ask user which blog they would like to add a post to.
                    Console.WriteLine("Which blog?");
                    var blogId = Console.ReadLine();

                    //Enter the post details.
                    Console.WriteLine("Enter a post title");
                    var title = Console.ReadLine();
                    Console.WriteLine("Enter post content");
                    var content = Console.ReadLine();
                    

                    var post = new Post();
                    post.Title = title;
                    post.Content = content;
                    post.BlogId = Convert.ToInt32(blogId);

                    context.Posts.Add(post);
                    context.SaveChanges();
                }

            }
            else if (userInput == "q")
            {
                Console.WriteLine("Program exiting...");
            }
                // Exit Program

            

            


        }
    }
}