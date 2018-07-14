using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCup.Entities;

namespace WorldCup.Repository
{
    internal class WorldCupDbInitializer : /*DropCreateDatabaseAlways<WorldCupDb>*/CreateDatabaseIfNotExists<WorldCupDb>
    {
        protected override void Seed(WorldCupDb context)
        {
            context.Teams.Add(new Team()
            {
                TeamId = 1,
                Name = "Portugal",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/por",
                Group = Group.B,
                Continent = Continent.Europe
            });

            context.Teams.Add(new Team()
            {
                TeamId = 2,
                Name = "Argentina",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/arg",
                Group = Group.D,
                Continent = Continent.SouthAmerica
            });

            context.Teams.Add(new Team()
            {
                TeamId = 3,
                Name = "Egypt",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/egy",
                Group = Group.A,
                Continent = Continent.Africa
            });

            context.Teams.Add(new Team()
            {
                TeamId = 4,
                Name = "Mexico",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/mex",
                Group = Group.F,
                Continent = Continent.NorthAmerica
            });

            context.Teams.Add(new Team()
            {
                TeamId = 5,
                Name = "Germany",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/ger",
                Group = Group.F,
                Continent = Continent.Europe
            });

            context.Teams.Add(new Team()
            {
                TeamId = 6,
                Name = "Australia",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/aus",
                Group = Group.C,
                Continent = Continent.Asia
            });

            context.Teams.Add(new Team()
            {
                TeamId = 7,
                Name = "Belgium",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/bel",
                Group = Group.G,
                Continent = Continent.Europe
            });

            context.Teams.Add(new Team()
            {
                TeamId = 8,
                Name = "Brazil",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/bra",
                Group = Group.E,
                Continent = Continent.SouthAmerica
            });

            context.Teams.Add(new Team()
            {
                TeamId = 9,
                Name = "Colombia",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/col",
                Group = Group.H,
                Continent = Continent.SouthAmerica
            });

            context.Teams.Add(new Team()
            {
                TeamId = 10,
                Name = "Russia",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/rus",
                Group = Group.A,
                Continent = Continent.Europe
            });

            context.Teams.Add(new Team()
            {
                TeamId = 11,
                Name = "Uruguay",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/uru",
                Group = Group.A,
                Continent = Continent.SouthAmerica
            });

            context.Teams.Add(new Team()
            {
                TeamId = 12,
                Name = "Saudi Arabia",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/ksa",
                Group = Group.A,
                Continent = Continent.Asia
            });

            context.Teams.Add(new Team()
            {
                TeamId = 13,
                Name = "IR Iran",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/irn",
                Group = Group.B,
                Continent = Continent.Asia
            });

            context.Teams.Add(new Team()
            {
                TeamId = 14,
                Name = "Spain",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/esp",
                Group = Group.B,
                Continent = Continent.Europe
            });

            context.Teams.Add(new Team()
            {
                TeamId = 15,
                Name = "Morocco",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/mar",
                Group = Group.B,
                Continent = Continent.Africa
            });

            context.Teams.Add(new Team()
            {
                TeamId = 16,
                Name = "France",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/fra",
                Group = Group.C,
                Continent = Continent.Europe
            });

            context.Teams.Add(new Team()
            {
                TeamId = 17,
                Name = "Denmark",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/den",
                Group = Group.C,
                Continent = Continent.Europe
            });

            context.Teams.Add(new Team()
            {
                TeamId = 18,
                Name = "Peru",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/per",
                Group = Group.C,
                Continent = Continent.SouthAmerica
            });

            context.Teams.Add(new Team()
            {
                TeamId = 19,
                Name = "Croatia",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/cro",
                Group = Group.D,
                Continent = Continent.Europe
            });

            context.Teams.Add(new Team()
            {
                TeamId = 20,
                Name = "Iceland",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/isl",
                Group = Group.D,
                Continent = Continent.Europe
            });

            context.Teams.Add(new Team()
            {
                TeamId = 21,
                Name = "Nigeria",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/nga",
                Group = Group.D,
                Continent = Continent.Africa
            });

            context.Teams.Add(new Team()
            {
                TeamId = 22,
                Name = "Serbia",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/srb",
                Group = Group.E,
                Continent = Continent.Europe
            });

            context.Teams.Add(new Team()
            {
                TeamId = 23,
                Name = "Switzerland",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/sui",
                Group = Group.E,
                Continent = Continent.Europe
            });

            context.Teams.Add(new Team()
            {
                TeamId = 24,
                Name = "Costa Rica",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/crc",
                Group = Group.E,
                Continent = Continent.NorthAmerica
            });

            context.Teams.Add(new Team()
            {
                TeamId = 25,
                Name = "Sweden",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/swe",
                Group = Group.F,
                Continent = Continent.Europe
            });

            context.Teams.Add(new Team()
            {
                TeamId = 26,
                Name = "Korea Republic",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/kor",
                Group = Group.F,
                Continent = Continent.Asia
            });

            context.Teams.Add(new Team()
            {
                TeamId = 27,
                Name = "Panama",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/pan",
                Group = Group.G,
                Continent = Continent.NorthAmerica
            });

            context.Teams.Add(new Team()
            {
                TeamId = 28,
                Name = "Tunisia",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/tun",
                Group = Group.G,
                Continent = Continent.Africa
            });

            context.Teams.Add(new Team()
            {
                TeamId = 29,
                Name = "England",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/eng",
                Group = Group.G,
                Continent = Continent.Europe
            });

            context.Teams.Add(new Team()
            {
                TeamId = 30,
                Name = "Poland",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/pol",
                Group = Group.H,
                Continent = Continent.Europe
            });

            context.Teams.Add(new Team()
            {
                TeamId = 31,
                Name = "Senegal",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/sen",
                Group = Group.H,
                Continent = Continent.Africa
            });

            context.Teams.Add(new Team()
            {
                TeamId = 32,
                Name = "Japan",
                FlagUrl = "https://api.fifa.com/api/v1/picture/flags-fwc2018-5/jpn",
                Group = Group.H,
                Continent = Continent.Asia
            });

            context.Players.Add(new Player()
            {
                PlayerName = "Cristiano Ronaldo",
                Age = 33,
                DateOfBirth = new DateTime(1985, 02, 05),
                Biography = @"The Real Madrid forward is Portugal’s captain, most capped player and leading all-time goalscorer. Still supremely fit and as committed as ever, he is more of a penalty box operator these days, having lost none of his scoring touch or his gift for breaking records. A formidable dribbler and a considerable aerial threat, Ronaldo is noted for his power, speed and instinct, qualities that have seen him named as the world’s best player on five occasions by FIFA.The most special of all the many honours he has won, however, is UEFA EURO 2016, his country’s first major trophy, which he had the honour of raising as skipper.The 2018 FIFA World Cup Russia™ will be his fourth world finals appearance.",
                PictureUrl = "https://api.fifa.com/api/v1/picture/players/2018fwc/201200_sq-300_jpg",
                Position = Position.CentreForward,
                PlayerTeamId =  1,
                GoalsScored = 84
            });

            context.Players.Add(new Player()
            {
                PlayerName = "Lionel Messi",
                Age = 30,
                DateOfBirth = new DateTime(1987, 06, 24),
                Biography = @"“This is Messi’s Argentina, not mine,” said Jorge Sampaoli, summing up just how important the Barcelona man is to the national side, a fact highlighted more clearly than ever during the qualifiers for the 2018 FIFA World Cup Russia™.

In the ten matches in which Messi played, La Albiceleste collected 21 of their final tally of 28 points, the result of six wins and three draws. Their only defeat in those ten games came away to Brazil.

Though Messi has said he is more of a team player than ever, there can be no doubting how much Argentina rely on him.

Messi momentarily retired from international football in 2016, halfway through the preliminaries, after losing a third final in three years with the national team. But as it turned out, he did not miss a single game, with a massive show of public support causing him to change his mind and attempt to heal the wounds of Brazil 2014 by having another crack at the world title at Russia 2018.",
                PictureUrl = "https://api.fifa.com/api/v1/picture/players/2018fwc/229397_sq-300_jpg",
                Position = Position.WingForward,
                PlayerTeamId =  2,
                GoalsScored = 64
            });

            context.Players.Add(new Player()
            {
                PlayerName = "Mohamed Salah",
                Age = 26,
                DateOfBirth = new DateTime(1992, 06, 15),
                Biography = @"The most globally-acclaimed player in the Egypt squad, Mohamed Salah has dazzled Europe over the last two seasons. Salah started out with Arab Contractors before making his way to Europe, and his goalscoring feats with Liverpool in 2017/18 have made him one of the most prolific players in all the continent's top five leagues.

The forward has excelled for his country too, leading the way for Egypt during the qualifiers for the 2018 FIFA World Cup™ with five goals. Two of those came in the crucial meeting with Congo which sealed qualification, and he will now be intent on helping the Pharaohs secure their first ever place in the knockout stage.",
                PictureUrl = "https://api.fifa.com/api/v1/picture/players/2018fwc/344654_sq-300_jpg",
                Position = Position.CentreForward,
                PlayerTeamId =  3,
                GoalsScored = 35
            });

            context.Players.Add(new Player()
            {
                PlayerName = "Javier Hernandez",
                Age = 30,
                DateOfBirth = new DateTime(1988, 06, 01),
                Biography = @"The spearhead of the Tri attack and its leading all-time goalscorer, Javier Hernandez began his career as a lethal penalty-box operator. Over the years, however, he has developed his ball skills and can often be found far from the opposition area.

A key player under Juan Carlos Osorio, Chicharito struck three goals in the qualifiers for the 2018 FIFA World Cup Russia™, two of them coming at home to Costa Rica and Trinidad and Tobago in the final six-team round.

A veteran of two World Cups, Hernandez now has the perfect opportunity to show why he has scored more goals for his country than anyone else.",
                PictureUrl = "https://api.fifa.com/api/v1/picture/players/2018fwc/228599_sq-300_jpg",
                Position = Position.CentreForward,
                PlayerTeamId =  4,
                GoalsScored = 49
            });

            context.Players.Add(new Player()
            {
                PlayerName = "Mats Hummels",
                Age = 29,
                DateOfBirth = new DateTime(1988, 12, 16),
                Biography = @"With his dominant aerial presence, masterful positional play and brilliant playmaking, Mats Hummels has long been regarded as one of Germany’s finest central defenders.

He began playing for Bayern Munich as a youngster before making his Bundesliga debut in 2007. After struggling to establish himself as a regular starter for FCB, he moved to Borussia Dortmund in 2008, winning two German championship titles and a DFB Cup during his time with the club. In 2016 he returned to Munich, where he continued to collect Bundesliga winners’ medals.

Although Hummels did not progress through the Germany youth ranks like many of his contemporaries, he was part of the U-21 side that lifted the European trophy in 2009 and went on to form the nucleus of the FIFA World Cup™-winning 2014 squad. Despite failing to make the plane to South Africa after making his senior international debut in 2010, he was a key figure at UEFA EURO 2012 and 2016 as well as at Brazil 2014.",
                PictureUrl = "https://api.fifa.com/api/v1/picture/players/2018fwc/311150_sq-300_jpg",
                Position = Position.CentreBack,
                PlayerTeamId =  5,
                GoalsScored = 5
            });

            context.Players.Add(new Player()
            {
                PlayerName = "Luka Modric",
                Age = 32,
                DateOfBirth = new DateTime(1985, 09, 09),
                Biography = @"Luka Modric has won everything possible at club level for Real Madrid, including the FIFA Club World Cup, but many believe Russia 2018 is his last chance to deliver on the international stage.

Although he had some joy at UEFA EURO 2008, when he was included in the team of the tournament, he has so far had no such luck at the FIFA World Cup. Two substitute appearances at Germany 2006 and three matches without distinction at Brazil 2014 are hardly fitting for such a sublime playmaker.

There is no question this unassuming star can deliver for his country when it matters though: over both legs in the World Cup play-off against Greece, Modric was the heart and brains of the team.",
                PictureUrl = "https://api.fifa.com/api/v1/picture/players/2018fwc/241559_sq-300_jpg",
                Position = Position.CentreBack,
                PlayerTeamId =  19,
                GoalsScored = 14
            });

            context.Players.Add(new Player()
            {
                PlayerName = "Harry Kane",
                Age = 24,
                DateOfBirth = new DateTime(1994, 07, 28),
                Biography = @"Captain Harry Kane is England’s undoubted talisman, leader and key player. The prolific Tottenham Hotspur man is a forward who can score all types of goals: with both feet, his head, from distance or from inside the six yard box – he has consistently found the net for club and country since bursting into the Spurs first team in the 2014-15 campaign, winning the English Premier League Golden Boot in 2015-16 and 2016-17.
To say then that England are reliant on Kane is a vast understatement. He played a pivotal role on the road to the 2018 FIFA World Cup Russia™, scoring winning goals against Slovenia and Lithuania and a late equaliser against Scotland – those three goals alone accounting for seven qualifying points. Kane will be looking to carry that influence into the finals themselves, and step up to the next level of superstardom by shining at a World Cup.",
                PictureUrl = "https://api.fifa.com/api/v1/picture/players/2018fwc/369419_sq-300_jpg",
                Position = Position.CentralMidfielder,
                PlayerTeamId = 29,
                GoalsScored = 19
            });

            context.Players.Add(new Player()
            {
                PlayerName = "Danijel Subasic",
                Age = 33,
                DateOfBirth = new DateTime(1984, 10, 27),
                Biography = @"Danijel Subasic had to wait a long time to secure his spot as Croatia’s number-one goalkeeper. Only after the retirement of Stipe Pletikosa, who played at the 2002, 2006 and 2014 World Cups, did the Zadar-born shotstopper inherit the starting jersey.

From that moment on, however, he has not disappointed: at UEFA EURO 2016 Suba was the hero in the decisive group-stage win against Spain, saving a penalty from Sergio Ramos.

At club level, Subasic is carving out a stellar career at AS Monaco, having joined as relative unknown from Hajduk Split in 2012. Since then, he has helped the club climb up into Ligue 1 and established himself as one of the leaders of the side. He played a vital role in the unforgettable 2016/17 season, when Monaco won the league title and reached the semi-finals of the UEFA Champions League. During his time in the principality, Subasic has also managed to beat off competition for the No1 shirt from two FIFA World Cup finalists: Argentina’s Sergio Romero and the Netherlands’ Maarten Stekelenburg.",
                PictureUrl = "https://api.fifa.com/api/v1/picture/players/2018fwc/299887_sq-300_jpg",
                Position = Position.Goalkeeper,
                PlayerTeamId = 19,
                GoalsScored = 0
            });

            context.Players.Add(new Player()
            {
                PlayerName = "Radamel Falcao",
                Age = 32,
                DateOfBirth = new DateTime(1986, 02, 10),
                Biography = @"“I’ve often pictured myself scoring a goal at a World Cup,” Radamel Falcao revealed to FIFA.com in January. With the disappointment of 2014 – when he missed out on the FIFA World Cup™ with a knee injury, after scoring nine goals in Colombia’s qualifying campaign – pushed firmly to the back of his mind, the clinical striker is now closer than ever to realising his dream. 

Following that injury, the road to recovery was long, and at times it was unclear whether or not the No9 would regain the form that had made him one of the world’s most fearsome forwards. In fact, a variety of physical problems saw him miss over half of La Tricolor’s qualifiers, but a rejuvenated Falcao bounced back in time for the decisive run-in, scoring a crucial goal in a draw with Brazil during the penultimate round of matches. World Cup defenders have been warned: Colombia’s all-time top goalscorer is back to his best.",
                PictureUrl = "https://api.fifa.com/api/v1/picture/players/2018fwc/229444_sq-300_jpg",
                Position = Position.CentreForward,
                PlayerTeamId = 9,
                GoalsScored = 30
            });

            context.Matches.Add(new Match()
            {
                MatchTime = new DateTime(2018, 06, 14),
                MatchType = MatchType.GroupMatch,
                Group = Group.A,
                StadiumLocation = StadiumLocation.MoscowLuzhniki,
                Team1Id = 10,
                Team2Id = 12,
                ScoreTeam1 = 5,
                ScoreTeam2 = 0
            });

            context.Matches.Add(new Match()
            {
                MatchTime = new DateTime(2018, 06, 15),
                MatchType = MatchType.GroupMatch,
                Group = Group.A,
                StadiumLocation = StadiumLocation.Ekaterinburg,
                Team1Id = 3,
                Team2Id = 11,
                ScoreTeam1 = 0,
                ScoreTeam2 = 1
            });

            context.Matches.Add(new Match()
            {
                MatchTime = new DateTime(2018, 06, 15),
                MatchType = MatchType.GroupMatch,
                Group = Group.B,
                StadiumLocation = StadiumLocation.SaintPetersburg,
                Team1Id = 15,
                Team2Id = 13,
                ScoreTeam1 = 0,
                ScoreTeam2 = 1
            });

            context.Matches.Add(new Match()
            {
                MatchTime = new DateTime(2018, 06, 15),
                MatchType = MatchType.GroupMatch,
                Group = Group.B,
                StadiumLocation = StadiumLocation.Sochi,
                Team1Id = 1,
                Team2Id = 14,
                ScoreTeam1 = 3,
                ScoreTeam2 = 3
            });

            context.Matches.Add(new Match()
            {
                MatchTime = new DateTime(2018, 06, 16),
                MatchType = MatchType.GroupMatch,
                Group = Group.C,
                StadiumLocation = StadiumLocation.Kazan,
                Team1Id = 16,
                Team2Id = 6,
                ScoreTeam1 = 2,
                ScoreTeam2 = 1
            });

            context.Matches.Add(new Match()
            {
                MatchTime = new DateTime(2018, 06, 16),
                MatchType = MatchType.GroupMatch,
                Group = Group.C,
                StadiumLocation = StadiumLocation.Saransk,
                Team1Id = 18,
                Team2Id = 17,
                ScoreTeam1 = 0,
                ScoreTeam2 = 1
            });

            context.Matches.Add(new Match()
            {
                MatchTime = new DateTime(2018, 06, 16),
                MatchType = MatchType.GroupMatch,
                Group = Group.D,
                StadiumLocation = StadiumLocation.Kaliningrad,
                Team1Id = 19,
                Team2Id = 21,
                ScoreTeam1 = 2,
                ScoreTeam2 = 0
            });

            context.Matches.Add(new Match()
            {
                MatchTime = new DateTime(2018, 06, 16),
                MatchType = MatchType.GroupMatch,
                Group = Group.D,
                StadiumLocation = StadiumLocation.MoscowSpartak,
                Team1Id = 2,
                Team2Id = 20,
                ScoreTeam1 = 1,
                ScoreTeam2 = 1
            });

            context.Matches.Add(new Match()
            {
                MatchTime = new DateTime(2018, 06, 30),
                MatchType = MatchType.RoundOf16,
                StadiumLocation = StadiumLocation.Kazan,
                Team1Id = 16,
                Team2Id = 2,
                ScoreTeam1 = 4,
                ScoreTeam2 = 3
            });

            context.Matches.Add(new Match()
            {
                MatchTime = new DateTime(2018, 07, 06),
                MatchType = MatchType.QuarterFinal,
                StadiumLocation = StadiumLocation.NizhnyNovgorod,
                Team1Id = 11,
                Team2Id = 16,
                ScoreTeam1 = 0,
                ScoreTeam2 = 2
            });

            context.Matches.Add(new Match()
            {
                MatchTime = new DateTime(2018, 07, 14),
                MatchType = MatchType.ThirdPlace,
                StadiumLocation = StadiumLocation.SaintPetersburg,
            });

            context.Matches.Add(new Match()
            {
                MatchTime = new DateTime(2018, 07, 15),
                MatchType = MatchType.Final,
                StadiumLocation = StadiumLocation.MoscowLuzhniki,
            });

            base.Seed(context);
        }
    }
}
