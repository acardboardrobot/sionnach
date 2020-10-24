using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Kabul;

namespace Sionnach
{
    public class SoundManager
    {
        FNAGame game;

        bool musicOn = true;

        SoundEffect buttonSelect1;
        SoundEffect music1;
        SoundEffect music2;
        SoundEffect battleClash;
        SoundEffect battleEnd;

        Song song, othersong, antsamraidh;

        public bool music1Playing = false;
        public bool music2Playing = false;

        SoundEffectInstance music1Ins, music2Ins;

        float fadeSpeed = 0.008f;

        Random random;

        public SoundManager(FNAGame Game)
        {
            game = Game;
            random = new Random();

            LoadContent();

            musicOn = true;
        }

        public void LoadContent()
        {
            /*
            FileStream fileStream = new FileStream("Content/Audio/button.wav");
            buttonSelect1 = SoundEffect.FromStream(fileStream);
            fileStream.Close();
            fileStream = new FileStream("Content/Audio/battleend.wav");
            battleEnd = SoundEffect.FromStream(fileStream);
            fileStream.Close();
            fileStream = new FileStream("Content/Audio/clash.wav");
            battleClash = SoundEffect.FromStream(fileStream);
            fileStream.Close();
            FileStream fileStream = new FileStream("Content/Audio/returnofaking.ogg");
            music1 = SoundEffect.FromStream(fileStream);
            fileStream.Close();
            music1Ins = music1.CreateInstance();
            fileStream = new FileStream("Content/Audio/music2.wav");
            music2 = SoundEffect.FromStream(fileStream);
            fileStream.Close();
            music2Ins = music2.CreateInstance();
            */
            Uri song1uri = new Uri(Environment.CurrentDirectory + "/Content/Audio/returnofaking.ogg");
            song = Song.FromUri("return", song1uri);

            Uri song2uri = new Uri(Environment.CurrentDirectory + "/Content/Audio/harvest.ogg");
            othersong = Song.FromUri("theme", song2uri);

            Uri song3uri = new Uri(Environment.CurrentDirectory + "/Content/Audio/antsamraidh.ogg");
            antsamraidh = Song.FromUri("samraidh", song3uri);
        }

        public void playButtonSound()
        {
            SoundEffectInstance sfInstance = buttonSelect1.CreateInstance();
            sfInstance.Play();
        }

        public void playBattleClash()
        {
            SoundEffectInstance sfInstance = battleClash.CreateInstance();
            sfInstance.Play();
        }
        public void playBattleEnd()
        {
            SoundEffectInstance sfInstance = battleEnd.CreateInstance();
            sfInstance.Play();
        }

        public void playMusic(int trackToPlay)
        {
            musicOn = true;
            if (trackToPlay == 1)
            {
                MediaPlayer.Play(song);
            }
            else if (trackToPlay == 2)
            {
                MediaPlayer.Play(othersong);
            }
            else if (trackToPlay == 3)
            {
                MediaPlayer.Play(antsamraidh);
            }
        }

        public void startMusic()
        {
            musicOn = true;
        }

        public void stopMusic()
        {
            MediaPlayer.Stop();
            musicOn = false;
        }

        public void Update()
        {
            if (MediaPlayer.State == MediaState.Stopped && musicOn)
            {
                playMusic(random.Next(1, 4));
            }
        }
    }
}
