using System;
using System.Linq;

namespace ViberBot.Viber
{
    public class GameCommand : Command
    {
        public override string commandName => "game";

        public override string description => "Начать игру.";

        private GameReplica[] gameReplics => new GameReplica[] {

            new GameReplica(0, "Одинм тихим летним вечером вы услышали, как зашипела рация. - Прием! Меня кто нибуть слышит?!", new GameRaplicaButton("Прием.", 1)),
            new GameReplica(1, "Отлично! Признаюсь боялся ни кто не услышит мой сигнал. Ты моя последняя надежда.", new GameRaplicaButton("Кто ты и что случилось?", 2)),
            new GameReplica(2, "Корабль 'Шустрый пони' на котором я путешествовал попал в сильный туман и налетел на рифы.", new GameRaplicaButton("Ты на спасательной шлюпке?", 3), new GameRaplicaButton("Пони теперь не такой шустрый, да?", 4)),
            new GameReplica(3, "Нет, я в пещере. Не понимаю, как здесь оказался.", new GameRaplicaButton("Что видишь вокруг?", 5)),
            new GameReplica(4, "Что?... Ааа-а... Хех. Да уж это точно.", new GameRaplicaButton("Что видишь вокруг?", 5)),
            new GameReplica(5, "Каменные глыбы. Одни свисают с потолка, другие тянутся к нему.", new GameRaplicaButton("...", 0))
        };

        public override string Execute(ViberCallbackEvent callbackEvent, object obj = null)
        {
            var delimiter = ';';

            var receiver = callbackEvent.senderId;

            var messageParts = callbackEvent.message.text.Split(new char[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

            var nextReplikaId = 0;

            if (messageParts.Length > 1)
            {
                int id;

                if (int.TryParse(messageParts[1], out id))
                {
                    nextReplikaId = id;
                }
            }

            var replica = gameReplics.First(r => r.id == nextReplikaId);

            var buttons = replica.buttons
                .Select(b => new ViberButton($"{Command.startChar}{commandName}{delimiter}{b.nextReplicaId}", b.text));

            return Utils.SendTextMessageWithButtons(receiver, replica.text, buttons.ToArray());
        }
    }
}
