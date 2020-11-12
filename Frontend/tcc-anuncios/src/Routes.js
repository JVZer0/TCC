import React from 'react'

import { BrowserRouter, Switch, Route } from 'react-router-dom'

import Inicial from './pages/Inicial';
import Login from './pages/Login';
import Home from './pages/Home';
import Anuncio from './pages/Anuncio'
import Cadastrar from './pages/Cadastrar Login';
import MeuPerfil from './pages/Meu perfil';
import RecuperarSenha from './pages/RecuperarSenha'
import Senha from './pages/Senha'
import MeusAnuncios from './pages/Meus anuncios'
import MeusFavoritos from './pages/Meus Favoritos'
import ExcluirAnuncio from './pages/Excluir anuncio'
import Desativar from './pages/Desativar'
import Anunciar from './pages/Inserir anuncio'
import AlterarAnuncio from './pages/Alterar anuncio'
import Responder from './pages/Responder'
import Relatorio from './pages/Relatorio'
import RelatorioUm from './pages/RelatorioUm'
import RelatorioDois from './pages/RelatorioDois'
import RelatorioTres from './pages/RelatorioTres'
import RelatorioQuatro from './pages/RelatorioQuatro'
import RelatorioCinco from './pages/RelatorioCinco'



export default function Routes(){
    return(
        <BrowserRouter>
            <Switch>
                <Route path="/" exact={true} component={Inicial} ></Route>
                <Route path="/Login" component={Login}></Route>
                <Route path="/Home" component={Home}></Route>
                <Route path="/Anuncio" component={Anuncio}></Route>
                <Route path="/Cadastrar" component={Cadastrar}></Route>
                <Route path="/MeuPerfil" component={MeuPerfil}></Route>
                <Route path="/RecuperarSenha" component={RecuperarSenha}></Route>
                <Route path="/Senha" component={Senha}></Route>
                <Route path="/MeusAnuncios" component={MeusAnuncios}></Route>
                <Route path="/MeusFavoritos" component={MeusFavoritos}></Route>
                <Route path="/ExcluirAnuncio" component={ExcluirAnuncio}></Route>
                <Route path="/Desativar" component={Desativar}></Route>
                <Route path="/Anunciar" component={Anunciar}></Route>
                <Route path="/AlterarAnuncio" component={AlterarAnuncio}></Route>
                <Route path="/Responder" component={Responder}></Route>
                <Route path="/RelatorioUm" component={RelatorioUm}></Route>
                <Route path="/RelatorioDois" component={RelatorioDois}></Route>
                <Route path="/RelatorioTres" component={RelatorioTres}></Route>
                <Route path="/RelatorioQuatro" component={RelatorioQuatro}></Route>
                <Route path="/RelatorioCinco" component={RelatorioCinco}></Route>
                <Route path="/Relatorio" component={Relatorio}></Route>
            </Switch>
        </BrowserRouter>
    )
}
