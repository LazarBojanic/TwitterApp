using System.Diagnostics;
using Tweetinvi;
using Tweetinvi.Core.Models;
using Tweetinvi.Models;

public class Twitter{
    private const string BEARER_TOKEN = "AAAAAAAAAAAAAAAAAAAAAMThgQEAAAAADE5hvOu2OCnN5ID0gToITu01268%3DfqltnmfxLjmuCgTWDxHTBFImseV9b1uLZ7YTyPjWE5LMid23px%3DNjFy0ubOy4jsxtIATjNXNBGI6e1Lp6ylWuf7q8kat3wEifFNHS";

    private const string CONSUMER_KEY = "RClpGCwQZXkKQDEoVPaQAkgQ6";
    private const string CONSUMER_SECRET = "eYJFIwGjW8a0Bwdg8O1a0vOxc3mV4OKJA92nTmTe1EQvN2Y3jC";

    private const string ACCESS_TOKEN = "4739677637-ffRqLxhvaExUA9bPOyjWZM77KpJEpcrLfuMtYQ8";
    private const string ACCESS_TOKEN_SECRET = "NjD5rVDgeYe3rftDA6nJcEciOPtPzfaAKETWGO4Eec8z6";

    private const string CLIENT_ID = "eXFOYlMwVHVoLVZtZnVLd05UM2o6MTpjaQ";
    private const string CLIENT_SECRET = "ibMvFUmWE0iG5IwBnzaSutctGGGSLpJAkPWBj4CxtQYhCXfbY6";

    static async Task Main(string[] args) {
        var appClient = new TwitterClient(CONSUMER_KEY, CONSUMER_SECRET);

        var authenticationRequest = await appClient.Auth.RequestAuthenticationUrlAsync();
        Process.Start(new ProcessStartInfo(authenticationRequest.AuthorizationURL) { UseShellExecute = true});
        Console.WriteLine("Please enter the code and press enter.");
        var pinCode = Console.ReadLine();
        var userCredentials = await appClient.Auth.RequestCredentialsFromVerifierCodeAsync(pinCode, authenticationRequest);
        var userClient = new TwitterClient(userCredentials);
        var user = await userClient.Users.GetAuthenticatedUserAsync();
        Console.WriteLine("Congratulation you have authenticated the user: " + user);

        var tweet = await userClient.Tweets.PublishTweetAsync("Test");
        Console.WriteLine("You published the tweet : " + tweet);
    }
}