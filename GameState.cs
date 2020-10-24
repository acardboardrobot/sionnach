using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using LineBatch;

namespace Sionnach
{
    public class GameState : State
    {
        SoundManager soundManager;
        public Texture2D TileSheet, cursorTexture;
        Sprite cursor;
        Rectangle cameraRec;
        Rectangle cullRec;
        Point cullBounds;
        List<Entity> collisionList;
        List<Entity> entities;
        int tickCount = 5000;
        int tickCounter = 5000;
        Rectangle checkRectangle;
        bool currentlyBuilding = false;
        UI gameUI;
        Vector2 currentMouseWorldPosition = new Vector2(500, 500);
        Color ghostBuildingColour = Color.DarkGray;

        bool drawPathfindDebug = false;

        EventManager eventManager;

        List<resourceSnapshot> gameSnapshots = new List<resourceSnapshot>();

        Text positionText;

        public GameState(StateManager stateMan)
        {

            stateManager = stateMan;
            soundManager = stateMan.game.soundManager;

            LoadContent();

            gameUI = new UI(stateManager);

            eventManager = new EventManager(gameUI);

            Console.WriteLine(entities.Count);

        }

        public override void LoadContent()
        {

            spriteBatch = stateManager.spriteBatch;

            Stream fileStream = TitleContainer.OpenStream("Content/TileSheet.png");
            TileSheet = Texture2D.FromStream(stateManager.game.GraphicsDevice, fileStream);
            fileStream.Close();

            fileStream = TitleContainer.OpenStream("Content/Cursors.png");
            cursorTexture = Texture2D.FromStream(stateManager.game.GraphicsDevice, fileStream);
            fileStream.Close();

            cursor = new Sprite(stateManager, cursorTexture, new Vector2(-50, 0), new Point(7, 7), new Point(0, 0));
            cursor.scale = 4;
            cursor.centreOrigin();

            
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null/*, camera.view*/);


            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);

            gameUI.Draw();
            cursor.Draw();

            spriteBatch.End();
        }        

        public override void HandleInput(InputHelper input, GameTime gameTime)
        {
            Point holder = input.cursorPosition; //camera.ConvertScreenToWorld(input.cursorPosition.X, input.cursorPosition.Y);
            Vector2 holderVec = new Vector2(holder.X, holder.Y);
            currentMouseWorldPosition = holderVec;

            cursor.position = Utilities.PointToVector2(input.cursorPosition);

            //positionText.text = currentMouseWorldPosition.X + ", " + currentMouseWorldPosition.Y;

            if (input.cursorPosition.X > Utilities.gameWindowWidth - 8)
            {

            }
            if (input.cursorPosition.X < 8)
            {
                
            }
            if (input.cursorPosition.Y > Utilities.gameWindowHeight - 8)
            {
                
            }
            if (input.cursorPosition.Y < 8)
            {
                
            }

            if (gameUI.UIRectangle.Contains(input.cursorPosition))
            {
                gameUI.HandleInput(input, gameTime);
            }
            else
            {
                if (input.IsNewMouseButtonRelease(MouseButtons.LeftButton))
                {

                }
                if (input.IsMouseButtonDown(MouseButtons.RightButton))
                {

                }

                if (input.IsMouseButtonDown(MouseButtons.MiddleButton))
                {
                    
                }

            }

            if (input.IsNewKeyRelease(Keys.G))
            {
                foreach(TrackingEvent tEvent in eventManager.getObjectives())
                {
                    gameUI.addPopup(tEvent.unfinishedString);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            UpdateCamera(gameTime);

            foreach (Entity e in entities.ToList())
            {
                e.Update(gameTime, collisionList);
            }

            if (tickCounter < 0)
            {
                tickCounter = tickCount;
            }
            else
            {
                tickCounter -= gameTime.ElapsedGameTime.Milliseconds;
            }

            gameUI.Update(gameTime);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            foreach (Entity t in entities)
            {
                t.Dispose();
            }
        }

        public bool checkVictoryConditions()
        {
            bool conditionsMet = false;

            //Hold list of victory conditions. For each non optional condition, loop through and add to a list to check for completion. If all are completed, then exit to end game state.
            /*foreach (VictoryConditionData victoryCondition in victoryConditions)
            {
                if (victoryCondition.optional == false)
                {

                }
            }*/

            if (eventManager.getObjectives().Count == 0)
            {
                conditionsMet = true;
            }

            if (conditionsMet)
            {
                UnloadContent();
                //stateManager.ExitAndLoad(new EndGameState(stateManager, gameSnapshots)); ;
            }

            return conditionsMet;
        }
        
        public void updateResourceCount()
        {
            
        }

        public void addPopup(string textforPopup)
        {
            gameUI.addPopup(textforPopup);
        }

        public void BuildingButtonClicked(object sender, EventArgs e)
        {

        }

        public void UpdateCamera(GameTime gameTime)
        {
            /*
             * camera.Update(gameTime);

            //Cull Floors, Debris, Walls, and GameObjs based on camera zoom + viewport size
            //match the viewport's width and height, keep camera rec at 0,0
            cameraRec.Width = stateManager.game.GraphicsDevice.Viewport.Width + 256;
            cameraRec.Height = stateManager.game.GraphicsDevice.Viewport.Height + 256;
            //place the cull rectangle at a world position that matches the camera rectangle's screen position
            cullRec.Location = camera.ConvertScreenToWorld(cameraRec.Location.X, cameraRec.Location.Y);
            //get the bounds of the camera view rec/viewport
            cullBounds = camera.ConvertScreenToWorld(cameraRec.Location.X + cameraRec.Width, cameraRec.Location.Y + cameraRec.Height);
            //set the cull rec's width and height based on cull bounds
            cullRec.Width = cullBounds.X - cullRec.Location.X;  //cullRec represents what the camera can see on screen currently
            cullRec.Height = cullBounds.Y - cullRec.Location.Y;
            */
        }

        public void addEvent(TrackingEvent newEvent)
        {
            eventManager.addEvent(newEvent);
        }
    }
}
