using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Animal : MonoBehaviour
{
    public GameObject prefab;
    public string Name;
    [SerializeField] protected string Type;
    public AlimentationType alimentation;
    public int age;
    public float speed;
    public int hungerness;
    public int thirstness;
    public int tiredness;
    public float minSpeed;
    public float maxSpeed;
    public float maxXp;
    public float xp;
    public int level;
    public int foodNeed = 1;
    public int foodNeededLevel;
    private List<string> names = new List<string> { "Rex", "Whiskers", "Fluffy", "Mittens", "Shadow", "Princess", "Spike", "Tiger", "Fifi", "Bubbles", "Lucky", "Champ", "Muffin", "Cinnamon", "Sparky", "Angel", "Misty", "Rocky", "Cupcake", "Cody", "Daisy", "Smokey", "Sassy", "Sunny", "Coco", "Max", "Mocha", "Peaches", "Midnight", "Rex", "Whiskers", "Fluffy", "Mittens", "Fido", "Shadow", "Bubbles", "Princess", "Smokey", "Rocky", "Lady", "Maximus", "Spike", "Cupcake", "Misty", "Bandit", "Lola", "Champ", "Muffin", "Zeus", "Daisy", "Simba", "Cinnamon", "Mocha", "Charlie", "Molly", "Buddy", "Ruby", "King", "Coco", "Atlas", "Nova", "Aurora", "Loki", "Zara", "Quasar", "Kai", "Luna", "Caspian", "Eva", "Phoenix", "Violet", "Orion", "Mila", "Titan", "Fiona", "Apollo", "Aria", "Jasper", "Isis", "Zephyr", "Zelda", "Cosmo", "Ivy", "Rocco", "Selene", "Finn", "Calypso", "Soren", "Sapphire", "Willow", "Milo", "Zelda", "Cairo", "Pepper", "Raven", "Maximus", "Athena", "Oscar", "Maple", "Koda", "Nova", "Simba", "Astrid", "Charlie", "Mochi", "Finnegan", "Sasha", "Riley", "Bentley", "Luna", "Cody", "Hazel", "Tucker", "Phoebe", "Rocco", "Coco", "Jax", "Daisy", "Kobe", "Maddie", "Gus", "Penelope", "Rusty", "Ivy", "Maverick", "Holly", "Zeus", "Suki", "Arlo", "Poppy", "Duke", "Lola", "Jasper", "Sadie", "Cooper", "Ruby", "Teddy", "Lily", "Blue", "Winston", "Chloe", "Jack", "Honey", "Maxwell", "Penny", "Ginger", "Bruno", "Sophie", "Rocky", "Zoe", "Bella", "Toby", "Kiki", "Ollie", "Nala", "Charlie", "Lola", "Henry", "Zara", "Rusty", "Lilly", "Apollo", "Misty", "Cleo", "Rufus", "Mila", "Loki", "Daisy", "Bentley", "Maddie", "Kai", "Layla", "Riley", "Coco", "Sasha", "Oliver", "Mia", "Kobe", "Rosie", "Gus", "Athena", "Harley", "Willow", "Mochi", "Jax", "Luna", "Baxter", "Layla", "Chester", "Vivienne", "Waldo", "Minnie", "Casper", "Isla", "Winston", "Pearl", "Remy", "Belle", "Fergus", "Peaches", "Archer", "Gigi", "Zeppelin", "Nova", "Rupert", "Ivy", "Tucker", "Talia", "Quincy", "Lola", "Rigby", "Gemma", "Otto", "Zara", "Olive", "Fletcher", "Phoebe", "Hugo", "Delilah", "Lincoln", "Cleo", "Mango", "Mabel", "Rico", "Willow", "Odin", "Dolly", "Oliver", "Jasmine", "Kingsley", "Pepper", "Fiona", "Colby", "Misty", "Gideon", "Poppy", "Rusty", "Lulu", "Monty", "Sofia", "Clyde", "Juno", "Duncan", "Pixie", "Oscar", "Coco", "Quinn", "Riley", "Gatsby", "Penny", "Ziggy", "Sophie", "Olivia", "Zorro", "Mia", "Apollo", "Sadie", "Hunter", "Snow", "Brady", "Sable", "Thor", "Phantom", "Maisie", "Colt", "Mila", "Hazel", "Rocco", "Maddox", "Leia", "Boomer", "Winnie", "Romeo", "Stella", "Bruno", "Indigo", "Molly", "Zane", "Xena", "Duke", "Ginger", "Baloo", "Athena", "Rusty", "Zelda", "Charlie", "Choco-Chip", "Snoozeberry", "Fluffernutter", "Waffles", "Bumble B.", "Fizzgig", "Whisker Doodle", "Sir Wigglesworth", "Snickerdoodle", "Muffin Top", "Banana Peel", "Snuggle Muffin", "Puddle Paws", "Pickle Pants", "Squigglekins", "Wiggly Woo", "Doodlebug", "Sprinkle Toes", "Silly Goose", "Mango Tango", "Bubbles McFluff", "Noodle Noggin", "Fuzzy McSnuggles", "Banjo Biscuit", "Scooter Pie", "Gigglesnort", "Munchkin", "Squishy Squash", "Noodle Noodlekins", "Snickerdoodle", "Bounce Bounce", "Wiggle Waggle", "Flapjack Fluff", "Peachy Keen", "Muffin Muff", "Scooter Doodle", "Fluff Bucket", "Toodle Puff", "Jellybean Jiggles", "Banana Bubbles", "Zigzag Zebra", "Pineapple Pickle", "Wobble Wobble", "Giggle Sprout", "Cheeseball Chuckle", "Tickle Toots", "Boogie Buns", "Gumdrop Giggles", "Pumpkin Pudding", "Pickle Peaches", "Jellybean Jamboree", "Twinkle Toes", "Noodle Napper", "Waffle Whiskers", "Bumble Beeble", "Gingersnap Guffaw", "Doodle Dip", "Sprinkle Sparkle", "Squiggle Squabble", "Whoopee Willow", "Sassafras Snickers", "Pumpernickel Puff", "Wobble Whisk", "Scooter Noodle", "Snuggle Snickers", "Wiggle Whisker", "Doodle Dipstick", "Fluffernoodle", "Giggle Gherkin", "Waffle Wobble", "Noodle Napper", "Snickerdoodle Snuggle", "Pickle Pumpernickel", "Jellybean Jamboree", "Muffin Muff", "Giggle Guffaw", "Boogie Bumble", "Squiggle Sprinkle", "Snoozeberry Socks", "Snickerdoodle Sassafras", "Waffle Wobble", "Fluffernoodle", "Giggle Gherkin", "Squiggle Noodle", "Jellybean Jamboree", "Pumpkin Pumpernickel", "Muffin Muff", "Waffle Whiskers", "Noodle Napper", "Tickle Toots", "Boogie Bumble", "Squishy Squash", "Peachy Keen", "Giggle Guffaw", "Doodle Dip", "Sprinkle Sparkle", "Squiggle Squabble", "Cheeseball Chuckle", "Jellybean Jiggles", "Banana Bubbles", "Scooter Muffin", "Snickerdoodle Waffle", "Giggly Groucho", "Fluffenstein", "Tickleberry Twist", "Mango Tango", "Ziggy Stardust", "Sassafras Fuzz", "Bubbles McSnicker", "Doodle Dabble", "Whisker Whiz", "Squiggle Snicker", "Peaches 'n Pudding", "Toodleberry Twist", "Giggle Gumbo", "Ziggy Zoom", "Waffle Whimsy", "Noodle Nectar", "Fluffernutter Niblet", "Snickers McTickle", "Jellybean Jive", "Banana Bonanza", "Muffin Mischief", "Bumbleberry Bounce", "Wiggle Waggle Woo", "Whoopee Wobble", "Cheeseball Chortle", "Pumpernickel Prank", "Pickle Pizzazz", "Squiggly Sneeze", "Scooter Snort", "Waffle Whinny", "Giggle Guffaw", "Noodle Nudge", "Sassafras Shuffle", "Flapjack Fiddle", "Mango Muddle", "Zigzag Zing", "Wobble Whistle", "Toodle Toot", "Giggle Giggleson", "Snicklefritz", "Jibber Jabber", "Muffin McFluffy", "Wiggle Wombat", "Whisker Wobble", "Noodle Noodlepop", "Pumpernickel Popcorn", "Snickerdoodle Snazzle", "Bumble Bumpkin", "Ziggy Zoodle", "Fart","Born Fat", "Sassafras Snickerdoodle", "Doodle Doppelpopper", "Waffle Wumblebee", "Fluffernutter Fizzle", "Tickle Tinseltail", "Mango Muffinman", "Scooter Sassafrassle", "Giggly Gobbledegook", "Toodle Tanglefoot", "Pumpernickel Piddlepaddle", "Cheeseball Chucklefritz", "Wobble Whimsywoo", "Jellybean Janglepants", "Bumble Bogglewump", "Squiggle Squabblepants", "Fluffernutter Flibberflabber", "Mango Mumbojumbo", "Whisker Wobblewhisk", "Noodle Noodleoodle", "Waffle Wobblewomp", "Toodle Tootletown", "Giggle Gobbledygook", "Scooter Snickerdoodle", "Ziggy Zapzap", "Sassafras Snorklewump", "Bumble Bopbop", "Mango Mufflenutter", "Wiggle Wobblepants", "Whoopee Wafflewhisk", "Jellybean Jibberjangle", "Fluffernutter Fizzleflop", "Tickle Tootlewobble", "Pumpernickel Puddlejump", "Cheeseball Chucklechimp", "Squiggle Squabblewhisk","The Nob Gobbler", "Wobble Whimsywhisk", "Toodle Tootlewaddle", "Giggle Gobbledoodle", "Scooter Snickerwhisk", "Ziggy Zoodlewhisk", "Sassafras Snickersnoodle", "Bumble Boppitybop", "Mango Mufflenoodle", "Wiggle Wobblepants", "Whoopee Wafflewhisk", "Jellybean Jibberjangle", "Fluffernutter Fizzleflop", "Tickle Tootlewobble", "Pumpernickel Puddlejump", "Cheeseball Chucklechimp", "Squiggle Squabblewhisk", "Wobble Whimsywhisk", "Toodle Tootlewaddle","Corn Hub", "Giggle Gobbledoodle","Krispy Krunck", "Scooter Snickerwhisk","Mike Oxmall", "Ziggy Zoodlewhisk", "Sassafras Snickersnoodle", "Bumble Boppitybop", "Mango Mufflenoodle", "Wiggle Wobblewhisk", "Whoopee Wafflewiggle", "Jellybean Jibberjabber", "Fluffernutter Fiddlefaddle", "Tickle Tootletwist", "Pumpernickel Puddlepop", "Cheeseball Chucklechomp", "Squiggle Squabblewiggle", "Wobble Whimsywobble", "Toodle Tootletwiggle", "Giggle Gobbledoodle", "Scooter Snickerdoodle", "Ziggy Zoodlewobble", "Sassafras Snickersnicker", "Bumble Boppityboop", "Mango Mufflenoodle", "Wiggle Wobblewhisk", "Whoopee Wafflewiggle", "Jellybean Jibberjabber", "Fluffernutter Fiddlefaddle", "Tickle Tootletwist", "Pumpernickel Puddlepop", "Cheeseball Chucklechomp", "Squiggle Squabblewiggle", "Wobble Whimsywobble", "Toodle Tootletwiggle","Dick", "Giggle Gobbledoodle", "Scooter Snickerdoodle", "Ziggy Zoodlewobble", "Sassafras Snickersnicker", "Bumble Boppityboop", "Mango Mufflenoodle", "Wiggle Wobblewhisk", "Whoopee Wafflewiggle", "Jellybean Jibberjabber", "Fluffernutter Fiddlefaddle", "Tickle Tootletwist", "Pumpernickel Puddlepop", "Cheeseball Chucklechomp", "Squiggle Squabblewiggle", "Wobble Whimsywobble", "Toodle Tootletwiggle", "Giggle Gobbledoodle", "Scooter Snickerdoodle", "Ziggy Zoodlewobble", "Sassafras Snickersnicker", "Bumble Boppityboop", "Mango Mufflenoodle", "Wiggle Wobblewhisk", "Whoopee Wafflewiggle", "Jellybean Jibberjabber", "Fluffernutter Fiddlefaddle", "Tickle Tootletwist", "Pumpernickel Puddlepop", "Cheeseball Chucklechomp", "Squiggle Squabblewiggle", "Wobble Whimsywobble", "Toodle Tootletwiggle", "Giggle Gobbledoodle", "Scooter Snickerdoodle", "Ziggy Zoodlewobble", "Sassafras Snickersnicker", "Bumble Boppityboop", "Mango Mufflenoodle", "Wiggle Wobblewhisk", "Whoopee Wafflewiggle", "Jellybean Jibberjabber", "Fluffernutter Fiddlefaddle", "Tickle Tootletwist", "Pumpernickel Puddlepop", "Cheeseball Chucklechomp", "Squiggle Squabblewiggle", "Wobble Whimsywobble", "Toodle Tootletwiggle", "Giggle Gobbledoodle", "Scooter Snickerdoodle", "Ziggy Zoodlewobble", "Sassafras Snickersnicker", "Bumble Boppityboop", "Mango Mufflenoodle", "Wiggle Wobblewhisk", "Whoopee Wafflewiggle", "Jellybean Jibberjabber", "Fluffernutter Fiddlefaddle", "Tickle Tootletwist","Deez", "Pumpernickel Puddlepop", "Cheeseball Chucklechomp", "Squiggle Squabblewiggle", "Wobble Whimsywobble", "Toodle Tootletwiggle", "Giggle Gobbledoodle", "Scooter Snickerdoodle", "Ziggy Zoodlewobble", "Sassafras Snickersnicker", "Bumble Boppityboop", "Mango Mufflenoodle", "Wiggle Wobblewhisk", "Whoopee Wafflewiggle", "Jellybean Jibberjabber", "Fluffernutter Fiddlefaddle", "Tickle Tootletwist", "Pumpernickel Puddlepop", "Cheeseball Chucklechomp", "Squiggle Squabblewiggle", "Wobble Whimsywobble", "Toodle Tootletwiggle", "Giggle Gobbledoodle", "Scooter Snickerdoodle", "Ziggy Zoodlewobble", "Sassafras Snickersnicker", "Bumble Boppityboop", "Mango Mufflenoodle", "Wiggle Wobblewhisk", "Whoopee Wafflewiggle", "Jellybean Jibberjabber", "Fluffernutter Fiddlefaddle", "Tickle Tootletwist", "Pumpernickel Puddlepop", "Cheeseball Chucklechomp","Skibidi Dob", "Squiggle Squabblewiggle", "Wobble Whimsywobble", "Toodle Tootletwiggle", "Giggle Gobbledoodle", "Scooter Snickerdoodle", "Ziggy Zoodlewobble", "Sassafras Snickersnicker", "Bumble Boppityboop", "Mango Mufflenoodle", "Wiggle Wobblewhisk", "Whoopee Wafflewiggle", "Jellybean Jibberjabber", "Fluffernutter Fiddlefaddle", "Tickle Tootletwist", "Pumpernickel Puddlepop", "Cheeseball Chucklechomp", "Squiggle Squabblewiggle", "Wobble Whimsywobble", "Toodle Tootletwiggle", "Giggle Gobbledoodle", "Scooter Snickerdoodle", "Ziggy Zoodlewobble", "Sassafras Snickersnicker", "Bumble Boppityboop", "Mango Mufflenoodle", "Wiggle Wobblewhisk", "Whoopee Wafflewiggle", "Jellybean Jibberjabber", "Fluffernutter Fiddlefaddle", "Tickle Tootletwist", "Pumpernickel Puddlepop", "Cheeseball Chucklechomp", "Squiggle Squabblewiggle", "Wobble Whimsywobble", "Toodle Tootletwiggle", "Giggle Gobbledoodle", "Scooter Snickerdoodle", "Ziggy Zoodlewobble", "Sassafras Snickersnicker", "Bumble Boppityboop", "Mango Mufflenoodle", "Wiggle Wobblewhisk", "Whoopee Wafflewiggle", "Jellybean Jibberjabber", "Fluffernutter Fiddlefaddle", "Tickle Tootletwist", "Pumpernickel Puddlepop", "Cheeseball Chucklechomp", "Squiggle Squabblewiggle", "Wobble Whimsywobble", "Toodle Tootletwiggle", "Giggle Gobbledoodle", "Scooter Snickerd", "Snickerdoodle Waffle", "Giggly Groucho", "Fluffenstein", "Tickleberry Twist", "Mango Tango", "Ziggy Stardust", "Sassafras Fuzz", "Bubbles McSnicker", "Doodle Dabble", "Whisker Whiz", "Squiggle Snicker", "Peaches 'n Pudding", "Toodleberry Twist", "Giggle Gumbo","Nuts", "Ziggy Zoom", "Waffle Whimsy", "Noodle Nectar", "Fluffernutter Niblet", "Snickers McTickle", "Jellybean Jive", "Banana Bonanza", "Muffin Mischief", "Bumbleberry Bounce", "Wiggle Waggle Woo", "Whoopee Wobble", "Cheeseball Chortle", "Pumpernickel Prank", "Pickle Pizzazz", "Squiggly Sneeze","Deez Nuts", "Scooter Snort", "Waffle Whinny", "Giggle Guffaw", "Noodle Nudge", "Sassafras Shuffle", "Flapjack Fiddle", "Mango Muddle", "Zigzag Zing", "Wobble Whistle", "Toodle Toot", "Giggle Guffaw", "Scooter Snicker", "Waffle Wiggle", "Noodle Noodle", "Sassafras Snort", "Fluffernutter Fizz", "Mango Mischief", "Ziggy Zip", "Pickle Prankster", "Jellybean Jester", "Banana Boomerang", "Waffle Wiggle", "Bumble Boink", "Fluffernutter Flap", "Giggly Galore", "Squiggle Snicker", "Scooter Snicker", "Waffle Whimsy", "Toodle Toot", "Giggle Guffaw", "Scooter Snicker", "Waffle Wiggle", "Noodle Noodle", "Sassafras Snort", "Fluffernutter Fizz", "Mango Mischief", "Ziggy Zip", "Pickle Prankster", "Jellybean Jester", "Banana Boomerang", "Waffle Wiggle", "Bumble Boink", "Fluffernutter Flap", "Giggly Galore", "Squiggle Snicker", "Whisker Doodle", "Scooter Pie", "Gigglesnort", "Munchkin", "Squishy Squash", "Noodle Noodlekins", "Snickerdoodle", "Bounce Bounce", "Wiggle Waggle", "Flapjack Fluff", "Peachy Keen", "Muffin Muff", "Scooter Doodle", "Fluff Bucket", "Toodle Puff", "Jellybean Jiggles", "Banana Bubbles", "Zigzag Zebra", "Pineapple Pickle", "Wobble Wobble", "Giggle Sprout", "Cheeseball Chuckle", "Tickle Toots", "Boogie Buns", "Gumdrop Giggles", "Pumpkin Pudding", "Pickle Peaches", "Jellybean Jamboree", "Twinkle Toes", "Noodle Napper", "Waffle Whiskers", "Bumble Beeble", "Gingersnap Guffaw", "Doodle Dip", "Sprinkle Sparkle", "Squiggle Squabble", "Whoopee Willow", "Sassafras Snickers", "Pumpernickel Puff", "Wobble Whisk", "Scooter Noodle", "Snuggle Snickers", "Wiggle Whisker", "Doodle Dipstick", "Fluffernoodle", "Giggle Gherkin", "Waffle Wobble", "Noodle Napper", "Snickerdoodle Snuggle", "Pickle Pumpernickel", "Jellybean Jamboree", "Muffin Muff", "Giggle Guffaw", "Boogie Bumble", "Squiggle Sprinkle", "Snoozeberry Socks", "Snickerdoodle Sassafras", "Waffle Wobble", "Fluffernoodle", "Giggle Gherkin", "Squiggle Noodle", "Jellybean Jamboree", "Pumpkin Pumpernickel", "Muffin Muff", "Waffle Whiskers", "Noodle Napper", "Tickle Toots", "Boogie Bumble", "Squishy Squash", "Peachy Keen", "Giggle Guffaw", "Doodle Dip", "Sprinkle Sparkle", "Squiggle Squabble", "Cheeseball Chuckle", "Jellybean Jiggles", "Banana Bubbles", "Scooter Muffin", "Snickerdoodle Waffle", "Giggly Groucho", "Fluffenstein", "Tickleberry Twist", "Mango Tango", "Ziggy Stardust", "Sassafras Fuzz", "Bubbles McSnicker", "Doodle Dabble", "Whisker Whiz", "Squiggle Snicker", "Peaches 'n Pudding", "Toodleberry Twist", "Giggle Gumbo", "Ziggy Zoom", "Waffle Whimsy", "Noodle Nectar", "Fluffernutter Niblet", "Snickers McTickle", "Jellybean Jive", "Banana Bonanza", "Muffin Mischief", "Bumbleberry Bounce", "Wiggle Waggle Woo", "Whoopee Wobble", "Cheeseball Chortle", "Pumpernickel Prank", "Pickle Pizzazz", "Squiggly Sneeze", "Scooter Snort", "Waffle Whinny", "Giggle Guffaw", "Noodle Nudge", "Sassafras Shuffle", "Flapjack Fiddle", "Mango Muddle", "Zigzag Zing", "Wobble Whistle", "Toodle Toot", "Giggle Guffaw", "Scooter Snicker", "Waffle Wiggle", "Noodle Noodle", "Sassafras Snort", "Fluffernutter Fizz", "Mango Mischief", "Ziggy Zip", "Pickle Prankster", "Jellybean Jester", "Banana Boomerang", "Waffle Wiggle", "Bumble Boink", "Fluffernutter Flap", "Giggly Galore", "Squiggle Snicker" };
    [SerializeField] protected GameObject enclot;

    private Vector2 targetPos;
    private bool canMove;

    private void Awake()
    {
        SetVariables();
        FindEnclot();
        targetPos = transform.position;
        SetRandomTargetPos(2);
        ReturnNextLevelValue();
    }
    private void Update()
    {
        Move();
        Rotate();
    }

    private void FindEnclot()
    {
        GameObject[] enclots = GameObject.FindGameObjectsWithTag("Enclot");
        float distance = Mathf.Infinity;
        int index = 0;
        for(int i = 0; i < enclots.Length; i++)
        { 
            if(distance > Vector3.Distance(gameObject.transform.position, enclots[i].transform.position))
            {
                distance = Vector3.Distance(gameObject.transform.position, enclots[i].transform.position);
                index = i;
            }
        }
        enclot = enclots[index];
    }

    private void SetVariables()
    {
        int index = Random.Range(0,names.Count);
        Name = names[index];
        foodNeed = 10;
        maxXp = 5;
        xp = 0;
    }
    public void Chill()
    {
        canMove = false;
        Invoke("StopChill", Random.Range(30, 60));
    }

    private void StopChill()
    {
        tiredness /= 2;
        SetRandomTargetPos(5);
    }

    public void Sleep()
    {
        canMove = false;
    }

    private void StopSleep()
    {

    }

    public void Eat()
    {
        if(hungerness <= 0)
        {
            xp += 1.5f;
            if(xp >= maxXp)
            {
                LevelUp();
            }
            GameManager.instance.SetResources(alimentation.ToString(), -foodNeed);
        }
        else
        {
            hungerness = 0;
        }
    }

    public void LevelUp()
    {
        xp -= maxXp;
        maxXp *= 1.2f;
        level++;
        foodNeed += foodNeed/2;
        if ( level % 5 == 0)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.2f, transform.localScale.y + 0.2f, transform.localScale.z);
        }
    }

    public void ReturnNextLevelValue()
    {
        int amount = 0;
        float temp = xp;
        bool whileExit = true;
        while (whileExit)
        {
            amount++;
            temp += 1.5f;
            if (temp >= maxXp)
            {
                whileExit = false;
            }
        }
        foodNeededLevel = amount;
    }

    public void SetRandomTargetPos(int range)
    {
        canMove = true;
        targetPos = new Vector2(Random.Range(enclot.transform.position.x - (enclot.GetComponent<Renderer>().bounds.size.x/2) + (GetComponent<Renderer>().bounds.size.x/2), enclot.transform.position.x + (enclot.GetComponent<Renderer>().bounds.size.x / 2) - (GetComponent<Renderer>().bounds.size.x / 2)),
            Random.Range(enclot.transform.position.y - (enclot.GetComponent<Renderer>().bounds.size.x / 2) + (GetComponent<Renderer>().bounds.size.x / 2), enclot.transform.position.y + (enclot.GetComponent<Renderer>().bounds.size.x / 2) - (GetComponent<Renderer>().bounds.size.x / 2)));
        ChangeSpeed(maxSpeed, minSpeed);
    }

    public void Move()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position,targetPos) <= 0.2f && canMove)
        {
            StopMove();
        }
    }

    public void StopMove()
    {
        canMove = false;
        int rnd = Random.Range(1, 100);
        if (rnd > 95 && tiredness >= 6)
        {
            Chill();
        }
        else
        {
            Invoke(nameof(CallSetRandomTargetPos), Random.Range(5, 15));
        }

    }

    private void Rotate()
    {
        Vector2 direction = targetPos - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * (180 / Mathf.PI);

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    private void ChangeSpeed(float max, float min)
    {
        speed = Random.Range(min, max);
    }

    public string GetAnimalType()
    {
        return Type;
    }

    private void CallSetRandomTargetPos()
    {
        SetRandomTargetPos(2);
    }

    public string GetAlimentationType()
    {
        return alimentation.ToString();
    }
    
}

public enum AlimentationType
{
    Fish,
    Vegetable,
    Meat
}