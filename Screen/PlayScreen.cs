using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GP_Midterm_BubblePuzzle.GameObjects;
using System;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using GP_Midterm_BubblePuzzle.Managers;
using Microsoft.Xna.Framework.Media;

namespace GP_Midterm_BubblePuzzle.Screen {
    class PlayScreen : _GameScreen {
        private Texture2D BG, Black, BubbleTexture, GunTexture;
        private SpriteFont Arial, Arcanista;
        private Bubble[,] bubble = new Bubble[9, 8];
        private Color _Color;
        private Random random = new Random();
        private Gun gun;
        private Vector2 fontSize;
        private float _timer = 0f;
        private float __timer = 0f;
        private float Timer = 0f;
        private float timerPerUpdate = 0.05f;
        private float tickPerUpdate = 30f;
        private int alpha = 255;
        private bool fadeFinish = false;
        private bool gameOver = false;
        private bool gameWin = false;
        private SoundEffectInstance BubbleSFX_stick, BubbleSFX_dead;
        private SoundEffectInstance Click;

        public void Initial() {
            _Color = new Color(255, 255, 255, alpha);
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 8 - (i % 2); j++) {
                    bubble[i, j] = new Bubble(BubbleTexture) {
                        Name = "Bubble",
                        Position = new Vector2((j * 80) + ((i % 2) == 0 ? 320 : 360), (i * 70) + 40),
                        color = GetRandomColor(),
                        IsActive = false,
                    };
                }
            }
            Click.Volume = Singleton.Instance.SFX_MasterVolume;
            BubbleSFX_stick.Volume = Singleton.Instance.SFX_MasterVolume;
            BubbleSFX_dead.Volume = Singleton.Instance.SFX_MasterVolume;
            gun = new Gun(GunTexture, BubbleTexture) {
                Name = "Gun",
                Position = new Vector2(Singleton.Instance.Diemensions.X / 2 - GunTexture.Width / 2, 700 - GunTexture.Height),
                color = Color.White,
                _deadSFX = BubbleSFX_dead,
                _stickSFX = BubbleSFX_stick,
                IsActive = true,
            };
        }

        public Color GetRandomColor() {
            Color _color = Color.Black;
            switch (random.Next(0, 6)) {
                case 0:
                    _color = Color.White;
                    break;
                case 1:
                    _color = Color.Blue;
                    break;
                case 2:
                    _color = Color.Yellow;
                    break;
                case 3:
                    _color = Color.Red;
                    break;
                case 4:
                    _color = Color.Green;
                    break;
                case 5:
                    _color = Color.Purple;
                    break;
            }
            return _color;
        }

        public bool CheckWin(Bubble[,] bubble) {
            for(int i=0;i<9;i++) {
                for(int j=0;j<8-(i%2);j++) {
                    if(bubble[i,j] != null) {
                        return false;
                    }
                }
            }
            return true;
        }
        public override void LoadContent() {
            base.LoadContent();
            BG = content.Load<Texture2D>("PlayScreen/BG");
            Black = content.Load<Texture2D>("SplashScreen/Black");
            BubbleTexture = content.Load<Texture2D>("PlayScreen/bubble_sheet");
            GunTexture = content.Load<Texture2D>("PlayScreen/bow_sheet");
            Arial = content.Load<SpriteFont>("Fonts/Arial");
            Arcanista = content.Load<SpriteFont>("Fonts/Arcanista");
            BubbleSFX_dead = content.Load<SoundEffect>("Audios/UI_SoundPack8_Error_v1").CreateInstance();
            BubbleSFX_stick = content.Load<SoundEffect>("Audios/UI_SoundPack11_Select_v14").CreateInstance();
            Click = content.Load<SoundEffect>("Audios/transition t07 two-step 007").CreateInstance();
            Initial();
        }
        public override void UnloadContent() {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime) {
            if (!gameOver && !gameWin) {
                for (int i = 0; i < 9; i++) {
                    for (int j = 0; j < 8; j++) {
                        if (bubble[i, j] != null)
                            bubble[i, j].Update(gameTime, bubble);
                    }
                }
                gun.Update(gameTime, bubble);
                Timer += (float)gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;
                for (int i = 0; i < 8; i++) {
                    if (bubble[8, i] != null) {
                        gameOver = true;
						Singleton.Instance.BestScore = Singleton.Instance.Score.ToString();
						Singleton.Instance.BestTime = Timer.ToString("F");
					}
                }
                //Check ball flying
                for (int i = 1; i < 9; i++) {
                    for (int j = 1; j < 7 - (i % 2); j++) {
                        if (i % 2 != 0) {
                            if (bubble[i - 1, j] == null && bubble[i - 1, j + 1] == null) {
                                bubble[i, j] = null;
                            }
                            if (bubble[i, 1] == null && bubble[i - 1, 0] == null && bubble[i - 1, 1] == null) {
                                bubble[i, 0] = null;
                            }
                            if (bubble[i, 5] == null && bubble[i - 1, 7] == null && bubble[i - 1, 6] == null) {
                                bubble[i, 6] = null;
                            }
                        } else {
                            if (bubble[i - 1, j - 1] == null && bubble[i - 1, j] == null) {
                                bubble[i, j] = null;
                            }
                            if (bubble[i - 1, 0] == null && bubble[i, 1] == null) {
                                bubble[i, 0] = null;
                            }
                            if (bubble[i - 1, 6] == null && bubble[i, 6] == null) {
                                bubble[i, 7] = null;
                            }
                        }
                    }
                }

                __timer += (float)gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;
                if (__timer >= tickPerUpdate) {
                    // Check game over before scroll
                    for (int i = 6; i < 9; i++) {
                        for (int j = 0; j < 8 - (i % 2); j++) {
                            if (bubble[i, j] != null) {
                                gameOver = true;
								Singleton.Instance.BestScore = Singleton.Instance.Score.ToString();
								Singleton.Instance.BestTime = Timer.ToString("F");
                            }
                        }
                    }
                    // Scroll position 
                    for (int i = 5; i >= 0; i--) {
                        for (int j = 0; j < 8 - (i % 2); j++) {
                            bubble[i + 2, j] = bubble[i, j];
                        }
                    }
                    // Draw new scroll position
                    for (int i = 0; i < 9; i++) {
                        for (int j = 0; j < 8 - (i % 2); j++) {
                            if (bubble[i, j] != null) {
                                bubble[i, j].Position = new Vector2((j * 80) + ((i % 2) == 0 ? 320 : 360), (i * 70) + 40);
                            }
                        }
                    }
                    //Random ball after scroll
                    for (int i = 0; i < 2; i++) {
                        for (int j = 0; j < 8 - (i % 2); j++) {
                            bubble[i, j] = new Bubble(BubbleTexture) {
                                Name = "Bubble",
                                Position = new Vector2((j * 80) + ((i % 2) == 0 ? 320 : 360), (i * 70) + 40),
                                color = GetRandomColor(),
                                IsActive = false,
                            };
                        }
                    }

                    __timer -= tickPerUpdate;
                }

                gameWin = CheckWin(bubble);

            } else {
                Singleton.Instance.MousePrevious = Singleton.Instance.MouseCurrent;
                Singleton.Instance.MouseCurrent = Mouse.GetState();
                if (Singleton.Instance.MouseCurrent.LeftButton == ButtonState.Pressed && Singleton.Instance.MousePrevious.LeftButton == ButtonState.Released) {
                    Singleton.Instance.Score = 0;
                    ScreenManager.Instance.LoadScreen(ScreenManager.GameScreenName.MenuScreen);
                }
            }
            // fade out
            if (!fadeFinish) {
                _timer += (float)gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;
                if (_timer >= timerPerUpdate) {
                    alpha -= 5;
                    _timer -= timerPerUpdate;
                    if (alpha <= 5) {
                        fadeFinish = true;
                    }
                    _Color.A = (byte)alpha;
                }
            }



            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(BG, Vector2.Zero, Color.White);
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 8; j++) {
                    if (bubble[i, j] != null)
                        bubble[i, j].Draw(spriteBatch);
                }
            }
            gun.Draw(spriteBatch);

            spriteBatch.DrawString(Arcanista, "Score : " + Singleton.Instance.Score, new Vector2(1060, 260), _Color);
            spriteBatch.DrawString(Arcanista, "Time : " + Timer.ToString("F"), new Vector2(20, 260), _Color);
            spriteBatch.DrawString(Arcanista, "Next Time : " + (tickPerUpdate - __timer).ToString("F"), new Vector2(20, 210), _Color);

            if (gameOver) {
                spriteBatch.Draw(Black, Vector2.Zero, new Color(255, 255, 255, 210));
                fontSize = Arial.MeasureString("GameOver !!");
                spriteBatch.DrawString(Arial, "GameOver !!", Singleton.Instance.Diemensions / 2 - fontSize / 2, _Color);
            }

            if (gameWin) {
                spriteBatch.Draw(Black, Vector2.Zero, new Color(255, 255, 255, 210));
                fontSize = Arial.MeasureString("GameWin !!");
                spriteBatch.DrawString(Arial, "GameWin !!", Singleton.Instance.Diemensions / 2 - fontSize / 2, _Color);
            }

            // Draw fade out
            if (!fadeFinish) {
                spriteBatch.Draw(Black, Vector2.Zero, _Color);
            }
        }
    }
}
