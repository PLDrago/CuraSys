using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CuraSys.Data;
using CuraSys.GUI.Panels;
using CuraSys.Models;

namespace CuraSys.GUI
{
    public class MainWindow : Form
    {
        private Panel sidebar = new();
        private Label titleLabel = new();
        private Panel contentPanel = new();
        private Panel cardPanel = new();
        private enum UserRole { None, Admin, Patient }
        private UserRole currentRole = UserRole.None;
        private Button? userButton = null;

        private Patient? currentPatient;

        public MainWindow()
        {
            Text = "CuraSys";
            Width = 1200;
            Height = 800;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            sidebar.Dock = DockStyle.Left;
            sidebar.Width = 200;
            sidebar.BackColor = Color.FromArgb(33, 74, 120);

            titleLabel.Text = "CuraSys";
            titleLabel.ForeColor = Color.White;
            titleLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(40, 30);
            sidebar.Controls.Add(titleLabel);

            int offsetY = 80;

            userButton = new Button
            {
                Text = "",
                Width = sidebar.Width,
                Height = 40,
                Location = new Point(0, offsetY),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(41, 96, 144),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
                FlatAppearance = { BorderSize = 0 },
                Visible = false
            };
            userButton.Click += (_, _) => ShowPatientDetails();
            sidebar.Controls.Add(userButton);
            offsetY += 50;

            string[] menuItems = {
                "Sign In", "Patients", "Appointments", "Doctors",
                "Medical Tests", "Prescriptions", "Billing", "Notifications"
            };

            foreach (string item in menuItems)
            {
                Button btn = new()
                {
                    Text = item,
                    Width = sidebar.Width,
                    Height = 40,
                    Location = new Point(0, offsetY),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(33, 74, 120),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(20, 0, 0, 0),
                    FlatAppearance = { BorderSize = 0 },
                    Tag = item
                };

                if (item == "Sign In")
                    btn.Click += (_, _) => ShowSignInPanel();

                sidebar.Controls.Add(btn);
                offsetY += 40;
            }

            Button logoutButton = new()
            {
                Text = "Logout",
                Height = 40,
                Dock = DockStyle.Bottom,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(33, 74, 120),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
                FlatAppearance = { BorderSize = 0 },
                Tag = "Logout"
            };
            logoutButton.Click += (_, _) => Application.Restart();
            sidebar.Controls.Add(logoutButton);

            Button settingsBtn = new()
            {
                Text = "Settings",
                Height = 40,
                Dock = DockStyle.Bottom,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(33, 74, 120),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
                FlatAppearance = { BorderSize = 0 },
                Tag = "Settings"
            };
            sidebar.Controls.Add(settingsBtn);

            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Color.FromArgb(227, 239, 247);

            cardPanel = new Panel
            {
                Width = 940,
                Height = 720,
                BackColor = Color.White,
                Location = new Point(20, 20)
            };

            cardPanel.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle bounds = cardPanel.ClientRectangle;
                int radius = 20;

                using GraphicsPath path = new();
                path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
                path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
                path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                cardPanel.Region = new Region(path);
            };

            contentPanel.Controls.Add(cardPanel);
            Controls.Add(contentPanel);
            Controls.Add(sidebar);

            ShowSignInPanel();
        }

        private void ShowSignInPanel()
        {
            var signIn = new SignInPanel();
            signIn.OnPatientLoginSuccess += patient =>
            {
                currentRole = UserRole.Patient;
                currentPatient = patient;
                userButton!.Text = $"{patient.FirstName} {patient.LastName}";
                AdjustSidebarForPatient();
                ShowPatientDashboard();
            };
            LoadView(signIn);
        }

        private void LoadView(Control view)
        {
            cardPanel.Controls.Clear();
            cardPanel.Controls.Add(view);
        }

        private void AdjustSidebarForPatient()
        {
            string[] allowed = { "Medical Tests", "Prescriptions", "Billing", "Notifications" };
            int offsetY = 125;

            foreach (Control c in sidebar.Controls)
            {
                if (c is Button btn && btn.Tag is string tag)
                {
                    if (tag == "Settings" || tag == "Logout") continue;
                    btn.Visible = allowed.Contains(tag);
                    if (btn.Visible)
                    {
                        btn.Location = new Point(0, offsetY);
                        offsetY += 40;
                    }
                }
            }

            userButton!.Visible = true;
            userButton.Location = new Point(0, 75);
        }

        private void ShowPatientDashboard()
        {
            LoadView(new Label
            {
                Text = $"Witaj, {currentPatient!.FirstName}!",
                Font = new Font("Segoe UI", 14, FontStyle.Italic),
                AutoSize = true,
                Location = new Point(30, 30)
            });
        }

        private void ShowPatientDetails()
        {
            if (currentPatient == null) return;

            var panel = new Panel
            {
                Width = 600,
                Height = 300,
                Location = new Point(30, 30),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            var fontLabel = new Font("Segoe UI", 11, FontStyle.Bold);
            var fontData = new Font("Segoe UI", 11, FontStyle.Regular);

            void AddRow(string label, string value, int top)
            {
                var lbl = new Label
                {
                    Text = label + ":",
                    Font = fontLabel,
                    Location = new Point(20, top),
                    AutoSize = true
                };

                var val = new Label
                {
                    Text = value,
                    Font = fontData,
                    Location = new Point(180, top),
                    AutoSize = true
                };

                panel.Controls.Add(lbl);
                panel.Controls.Add(val);
            }

            AddRow("Imię", currentPatient.FirstName, 20);
            AddRow("Nazwisko", currentPatient.LastName, 50);
            AddRow("PESEL", currentPatient.Pesel, 80);
            AddRow("Telefon", currentPatient.Phone, 110);
            AddRow("Email", currentPatient.Email, 140);
            AddRow("Miasto", currentPatient.City, 170);
            AddRow("Adres", currentPatient.Address, 200);
            AddRow("Kod pocztowy", currentPatient.PostalCode, 230);
            AddRow("Data urodzenia", currentPatient.BirthDate.ToShortDateString(), 260);

            LoadView(panel);
        }
    }
}
