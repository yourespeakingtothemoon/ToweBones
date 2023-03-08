namespace ToweBones.Models
{
	public class DaStory
	{
		public enum Weather
			{
			SNOW,
			RAIN,
			CLOUDY,
			SUNNY,
			INSANEO_STYLE
		}
		public string StoryIntro { get; set; }
		public string Story1 { get; set; }
		public string Story2 { get; set; }
		public string Story3 { get; set; }
		public string Story4 { get; set; }
		//private Weather weather { get; set; }

		public DaStory(Weather weather)
		{
			switch(weather)
			{
				case Weather.SNOW:
					StoryIntro = "It was a cold and snowy day. The contemporary jazz classic Skating by Vince Guaraldi was playing on the loudspeakers.";
					break;
				case Weather.CLOUDY:
					StoryIntro = "It was a cloudy day. The pop classic California Dreamin' by the Mommas and Poppas was playing on the loudspeakers.";
					break;
				case Weather.RAIN:
					StoryIntro = "It was a rainy day. The Disney classic Little April Showers from the film Bambi was playing on the loudspeakers.";
					break;
				case Weather.SUNNY:
					StoryIntro = "It was a bright and sunny day. The nerd rock classic Holiday by Weezer was playing on the loudspeakers.";
					break;
				case Weather.INSANEO_STYLE:
					StoryIntro = "The day was totally insaneo style.";
					//add thirty random characters to the story
					for (int i = 0; i < 30; i++)
					{
						Story1 += (char)('a' + new Random().Next(0, 300));
					}
					StoryIntro += " ";
					break;
				default:
					StoryIntro = "It was a day.";
					break;

			}
			
			int random = new Random().Next(1, 7);
			switch (random)
			{
				case 1:
					Story1 += "Spooky, the skeleton with a penchant for fashion, found himself in the middle of an endless department store. He had lost his beloved golden monocle, a treasured possession he had acquired after defeating the evil wizard who had stolen it from him. Determined to get it back, Spooky donned his signature purple cape and top hat and began his quest, fighting through hordes of enemies and dodging traps at every turn.";
					break;
				case 2:
					Story1 += " Spooky, the dapper skeleton, found himself in a sprawling department store, searching for his lost golden monocle. As he made his way through the shelves and displays, he encountered all manner of strange and terrifying creatures, from animated mannequins to mischievous gremlins. But Spooky was undaunted, determined to retrieve his monocle at any cost.";
					break;
				case 3:
					Story1 += "Spooky, the well-dressed skeleton, found himself lost in a never-ending department store. He had been separated from his golden monocle, a precious artifact that had been in his family for generations, and was now on a mission to find it. Along the way, he battled through countless obstacles and fought off fierce enemies, his trusty purple cape and top hat billowing in the wind.";
					break;
				case 4:
					Story1 += "Spooky, the stylish skeleton, found himself trapped in a labyrinthine department store. His golden monocle, a prized possession he had inherited from his grandfather, had been stolen by a band of mischievous goblins, and Spooky was determined to get it back. As he navigated through the winding aisles and fought off the goblin hordes, Spooky's purple cape and top hat were a constant reminder of his unyielding determination.";
					break;
				case 5:
					Story1 += "Spooky, the fashion-forward skeleton, found himself deep in the heart of a vast department store. He had lost his golden monocle, a cherished family heirloom, and was determined to reclaim it at all costs. But the journey was perilous, as Spooky had to fight through a gauntlet of enemies and avoid deadly traps. With his trusty purple cape and top hat, Spooky fought on, his resolve unwavering even in the face of the greatest challenges.";
					break;
				default:
					//add 100 random characters of any kind
					for (int i = 0; i < 100; i++)
					{
						Story1 += (char)('a' + new Random().Next(0, 300));
					}
					break;
			}
			//generate paragraph 2
			random = new Random().Next(1, 7);
			switch(random)
			{
				case 1:
					Story2 = "Spooky had always been a creature of style and elegance, even in death. He spent his days lounging in his mansion, dressed in his finest attire and sipping on a glass of red wine. But one day, disaster struck – Spooky's golden monocle, a prized possession that he had inherited from his grandfather, went missing. Spooky searched high and low throughout his mansion, but to no avail. He soon realized that he would need to venture outside if he hoped to find his lost treasure.";
					break;
				case 2:
					Story2 = "For years, Spooky had been the talk of the town – a fashionable and eccentric skeleton who turned heads wherever he went. His purple cape and top hat had become his signature look, and he wore them with pride. But when his golden monocle went missing, Spooky knew that he would need to go to great lengths to get it back.";
					break;
				case 3:
					Story2 = "Spooky had always been a bit of an outsider, even among the other skeletons in the graveyard. He spent his days reading books on fashion and style, dreaming of a life beyond the confines of his tomb. But when his beloved monocle went missing, Spooky knew that he would need to venture out into the world to retrieve it.";
					
						break;
				case 4:
					Story2 = "Spooky had always been something of a rebel, even in life. He had never quite fit in with the corporate types who ran the department store, and he often found himself at odds with their policies and practices. But when his golden monocle went missing, Spooky knew that he would need to fight his way through the heart of the department store to get it back.";
					break;
				case 5:
					Story2 = "Spooky had always been a bit of a troublemaker, even as a young skeleton. He spent his days causing mischief and mayhem, much to the chagrin of his parents and peers. But as he grew older, Spooky began to realize the true value of his golden monocle – a family heirloom that had been passed down for generations.";
					break;
				default:
					//add 100 random characters of any kind
					for (int i = 0; i < 100; i++)
					{
						Story2 += (char)('a' + new Random().Next(0, 300));
					}
					break;

			}

			random = new Random().Next(1, 7);
			switch (random)
			{
				case 1:
					Story3 = "As he set out into the stormy night, Spooky couldn't help but feel a sense of foreboding. He had heard rumors of a vast department store on the outskirts of town, a place where strange and dangerous creatures were said to lurk. But Spooky was determined to find his monocle, no matter the cost.";
					break;
				case 2:
					Story3= "And so, he found himself standing outside the department store – a massive, sprawling building that seemed to stretch on for miles. The neon lights and flashing signs were overwhelming, and Spooky couldn't help but feel a sense of unease as he stepped inside. Little did he know, he was about to embark on the fight of his life.";
					break;
				case 3:
					Story3 = "The department store was unlike anything Spooky had ever seen before. It was a maze of shelves and displays, filled with all manner of strange and frightening creatures. But Spooky was not one to back down from a challenge. Armed with his trusty cane and his wits, he set out to reclaim his monocle and prove that even a skeleton could be a hero.";

					break;
				case 4:
					Story3 = "As he made his way through the aisles, Spooky encountered all manner of obstacles and adversaries. The corporate goons that patrolled the store were determined to stop him at all costs, but Spooky was not easily deterred. With his cane in hand and his quick wit at the ready, he pushed forward into the heart of the department store, determined to reclaim his rightful property.";
					break;
				case 5:
					Story3 = "When the monocle went missing, Spooky knew that he would need to take matters into his own hands. He donned his purple cape and top hat, and set out into the world. The department store loomed ahead of him, its bright lights and colorful displays";
					break;
				default:
					//add 100 random characters of any kind
					for (int i = 0; i < 100; i++)
					{
						Story3 += (char)('a' + new Random().Next(0, 300));
					}
					break;

			}

		
			//Story += "<br/> Join Spooky on his epic quest to retrieve his golden monocle, prove your skills in this exciting new game, put your gaming skills to the test and battle your way through an endless department store filled with danger, show off your skills as a gamer and take on the challenge - play now!";


		}

		
	}
}
