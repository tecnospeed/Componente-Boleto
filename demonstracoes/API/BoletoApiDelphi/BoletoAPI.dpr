program BoletoAPI;

uses
  Vcl.Forms,
  Unit1 in 'Unit1.pas' {Boleto};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TBoleto, Boleto);
  Application.Run;
end.
