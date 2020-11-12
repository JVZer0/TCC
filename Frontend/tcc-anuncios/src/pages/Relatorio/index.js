import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Meus Favoritos/style.css';

import Logo from '../../assets/image/Capturar.PNG'

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function Home(props){

    const [infos, setInfos] = useState(props.location.state);

    return(
        <div className="eiei">
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname: "/Home", state: infos}} ><img class="logo" src={Logo} src={Logo} width="180" height="34px" alt=''/></Link>
                </div>
            </div>

            <Link class="tango" to={{ pathname: "/RelatorioUm", state: infos}}>RelatorioUm</Link>
            <Link class="tango" to={{ pathname: "/RelatorioDois", state: infos}}>RelatorioDois</Link>
            <Link class="tango" to={{ pathname: "/RelatorioTres", state: infos}}>RelatorioTres</Link>
            <Link class="tango" to={{ pathname: "/RelatorioQuatro", state: infos}}>RelatorioQuatro</Link>
            <Link class="tango" to={{ pathname: "/RelatorioCinco", state: infos}}>RelatorioCinco</Link>

            <div className="rodape">
                    <div className="tey">
                        <h4>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h4>
                    </div>
            </div>
        </div>
    )
}