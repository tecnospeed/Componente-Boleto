program Project1;

uses
  Vcl.Forms,
  Unit1 in 'Unit1.pas' {frmExemploBoletoX};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TfrmExemploBoletoX, frmExemploBoletoX);
  Application.Run;
end.
