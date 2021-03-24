import * as React from 'react';
import AppBar from '@material-ui/core/AppBar';
import Container from '@material-ui/core/Container';
import CssBaseline from '@material-ui/core/CssBaseline';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import { createMuiTheme, MuiThemeProvider } from '@material-ui/core/styles';

import logo from './logo.svg';
import './App.css';

const RoskildeFestivalMuiTheme = createMuiTheme({
  // palette: {
  // 	primary: {
  // 		// main: '#ee7203' // RF Orange
  // 	}
  // },
  typography: {
    // useNextVariants: true
  },
  shape: {
    borderRadius: 8
  },
  overrides: {
    MuiCssBaseline: {
      '@global': {
        html: {
          WebkitFontSmoothing: 'auto',
        },
      },
    },
    MuiDrawer: {
      paper: {
        backgroundColor: '#18202c'
      }
    },
    MuiDivider: {
      root: {
        backgroundColor: '#404854'
      }
    },
    MuiListItemText: {
      primary: {
        fontWeight: 500
      }
    },
    MuiListItemIcon: {
      root: {
        color: 'inherit',
        marginRight: 0,
        '& svg': {
          fontSize: 20
        }
      }
    }
  }
});

function App() {
  return (
    <MuiThemeProvider theme={RoskildeFestivalMuiTheme}>
      <CssBaseline />
      <AppBar>
        <Toolbar>
          <Typography variant="h6">Felicya</Typography>
        </Toolbar>
      </AppBar>
      <Toolbar />
      <Container>
        <header className="App-header">
          <img src={logo} alt="Roskilde Festival Logo" />
          VELKOMMEN TIL FELICYA
[FEstival LIvsCYklus Analyse]
        </header>
        <main>
        Sammen indsamler vi viden og data for at passe på vores klima

        Opret projekt
ROSKILDE FESTIVAL 2021
Opbygning LARGE byggeri og scener [A]
Opbygning SMALL Installation/møbeldesign [B]
Opbygning MEDIUM Områdedeco [C]
Logistik bestillinger [D]
Artist booking [E]
RF ÅRET RUNDT
RFX [F]
Vedligehold af pladsen [G]
Søg/rediger projekt
        </main>
        <footer>&copy; 2021 Roskilde Festival</footer>
      </Container>
    </MuiThemeProvider>
  );
}

export default App;
