using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.IO;
using Kabul;

namespace Sionnach
{
    public class StateManager
    {
        public FNAGame game;
        public GameTime gameTime;
        public List<State> states;
        public List<State> statesToUpdate;
        public SpriteBatch spriteBatch;
        public bool coveredByOtherState;
        public int transitionCount;
        public InputHelper input;
        public Random random = new Random();
        public Matrix drawMatrix = Matrix.CreateScale(4, 4, 1);
        Color clearColour = new Color(40, 40, 40);
        public Texture2D buildingStatusIcons;

        public StateManager(FNAGame Game)
        {
            game = Game;
            input = new InputHelper(this);
            states = new List<State>();
            statesToUpdate = new List<State>();
        }

        public void Initialise()
        {
            spriteBatch = game.spriteBatch;
            spriteBatch.Begin();
            spriteBatch.Draw(new Texture2D(spriteBatch.GraphicsDevice, 20, 20), new Vector2(20, 20), Color.Green);
            spriteBatch.End();
            spriteBatch.GraphicsDevice.Clear(Color.Red);

            LoadContent();
        }

        public void LoadContent()
        {
            Stream fileStream = TitleContainer.OpenStream("Content/BuildingStatusIcons.png");
            buildingStatusIcons = Texture2D.FromStream(spriteBatch.GraphicsDevice, fileStream);
            fileStream.Close();
        }

        public void UnloadContent()
        {
            foreach (State s in states) { s.UnloadContent(); };
        }

        public void AddState(State state)
        {
            state.stateManager = this;
            state.LoadContent();
            states.Add(state);
        }

        public void RemoveState(State state)
        {
            state.UnloadContent();
            states.Remove(state);
            statesToUpdate.Remove(state);
        }
        public State[] GetStates() { return states.ToArray(); }

        public void ExitAndLoad(State stateToLoad)
        {   //remove every state on states list
            while (states.Count > 0)
            {
                try
                {
                    states[0].UnloadContent();
                    statesToUpdate.Remove(states[0]);
                    states.Remove(states[0]);
                }
                catch { }
            }
            this.AddState(stateToLoad);
        }

        public void Update(GameTime GameTime)
        {
            gameTime = GameTime;    //capture the game's current time
            input.Update(gameTime); //read the keyboard and gamepad

            //make a copy of the master state list, to avoid confusion if
            //the process of updating one state adds or removes others
            statesToUpdate.Clear();
            foreach (State state in states) { statesToUpdate.Add(state); }
            coveredByOtherState = false;

            //loop as long as there are states waiting to be updated.
            while (statesToUpdate.Count > 0)
            {   //remove the topmost state from the waiting list
                State state = statesToUpdate[statesToUpdate.Count - 1];
                statesToUpdate.RemoveAt(statesToUpdate.Count - 1);

                if (coveredByOtherState == false) //targeting the top most state
                {   //update & send input only to the top state
                    state.HandleInput(input, gameTime);
                    state.Update(gameTime);
                    coveredByOtherState = true; //no update/input to states below top
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(clearColour); //draw the game's background color
            
            foreach (State state in states)
            { 
                state.Draw(gameTime);
            }

        }
    }
}