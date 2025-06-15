namespace ScrumMaui.Views.Spring;

public partial class NewSpring : ContentPage
{
	public NewSpring()
	{
		InitializeComponent();
	}
    private void btnCreateBacklog_Clicked(object sender, EventArgs e)
    {
        Shell.Current.Navigation.PushModalAsync(new CreateSpringList());
    }
    private void btnAccept_Clicked(object sender, EventArgs e)
    {
        ValidateFields();
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        ResetFields();
    }

    private void ValidateFields()
    {
        bool isValid = true;

        if (StartDate.Date > DateTime.Now.AddMonths(1))
        {
            isValid = false;
            lblErrStartDate.Text = "La fecha inicio no debe superar 1 mes de la actual";
            lblErrStartDate.IsVisible = true;
        }
        else if (StartDate.Date < DateTime.Now)
        {
            isValid = false;
            lblErrStartDate.Text = "La fecha inicio debe ser mayor que la fecha actual";
            lblErrStartDate.IsVisible = true;
        }

        if (EndDate.Date > DateTime.Now.AddMonths(2))
        {
            isValid = false;
            lblErrEndDate.Text = "La fecha fin no debe superar 2 meses de la actual";
            lblErrEndDate.IsVisible = true;
        }
        else if (EndDate.Date <= DateTime.Now.AddMonths(1))
        {
            isValid = false;
            lblErrEndDate.Text = "La fecha fin debe ser mayor a la fecha actual + 1 mes";
            lblErrEndDate.IsVisible = true;
        }

        if (string.IsNullOrWhiteSpace(txtSpringName.Text))
        {
            isValid = false;
            lblErrSpringName.Text = "Se requiere un valor para el nombre del spring";
            lblErrSpringName.IsVisible = true;
        }

        if (string.IsNullOrWhiteSpace(txtObjective.Text))
        {
            isValid = false;
            lblErrObjective.Text = "Se requiere un valor para el objetivo";
            lblErrObjective.IsVisible = true;
        }

        if (string.IsNullOrWhiteSpace(txtAcceptance.Text))
        {
            isValid = false;
            lblErrAcceptance.Text = "Se requiere un valor para el criterio aceptación";
            lblErrAcceptance.IsVisible = true;
        }

        if (string.IsNullOrWhiteSpace(txtPointValue.Text))
        {
            isValid = false;
            lblErrPointValue.Text = "Se requiere un valor puntual";
            lblErrPointValue.IsVisible = true;
        }
        else if (int.TryParse(txtPointValue.Text, out int val))
        {
            if (val < 100 || val > 2000)
            {
                isValid = false;
                lblErrPointValue.Text = "El valor debe estar entre 100 y 2000";
                lblErrPointValue.IsVisible = true;
            }
        }

        if (!isValid)
        {
            lblErrGlobal.Text = "Por favor revise los datos de entrada";
            lblErrGlobal.IsVisible = true;
        }
        else
        {
            ClearErrors();
            DisplayAlert("Nuevo Spring", "El Spring se ha creado correctamente.", "Ok");
            ResetInputs();
        }
    }

    private void ResetFields()
    {
        ClearErrors();
        ResetInputs();
    }

    private void ClearErrors()
    {
        lblErrStartDate.Text = "";
        lblErrEndDate.Text = "";
        lblErrSpringName.Text = "";
        lblErrObjective.Text = "";
        lblErrAcceptance.Text = "";
        lblErrPointValue.Text = "";
        lblErrGlobal.Text = "";

        lblErrStartDate.IsVisible = false;
        lblErrEndDate.IsVisible = false;
        lblErrSpringName.IsVisible = false;
        lblErrObjective.IsVisible = false;
        lblErrAcceptance.IsVisible = false;
        lblErrPointValue.IsVisible = false;
        lblErrGlobal.IsVisible = false;
    }

    private void ResetInputs()
    {
        StartDate.Date = DateTime.Now;
        EndDate.Date = DateTime.Now.AddMonths(1);
        txtSpringName.Text = "";
        txtObjective.Text = "";
        txtAcceptance.Text = "";
        txtPointValue.Text = "";
    }
}