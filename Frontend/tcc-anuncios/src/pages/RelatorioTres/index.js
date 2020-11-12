import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Meus Favoritos/style.css';

import Logo from '../../assets/image/Capturar.PNG'

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function Home(props){

    const [infos, setInfos] = useState(props.location.state);
    const [anunciantesTop, setAnunciantesTop] = useState([]);

    const consultar = async () => {
        const resp = await api.relatoriosTopAnunciantes();
        setAnunciantesTop(resp);
    }

    useEffect(() => {
        consultar();
      }, []);

    return(
        <div className="eiei">
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname: "/Relatorio", state: infos}} ><img class="logo" src={Logo} width="180" height="34px" alt=''/></Link>
                </div>
            </div>


            <div class="tabela1">
                <div className="shit1">
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Nome</th>
                                <th>E-mail</th>
                                <th>Telefone</th>
                                <th>Qtd. Anuncios postados</th>
                                <th>Soma dos preços anunciados</th>
                            </tr>
                        </thead>

                        <tbody>
                            {anunciantesTop.map(x =>
                            <tr>
                                <td>{x.nome}</td>
                                <td>{x.email}</td>
                                <td>{x.celular}</td>
                                <td>{x.qtdAnuncios}</td>
                                <td>{x.somaDosPrecoDosAnuncios}</td>
                            </tr>
                            )} 
                        </tbody>
                    </table>
                </div>
            </div>

            <div className="rodape">
                    <div className="tey">
                        <h4>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h4>
                    </div>
            </div>
        </div>
    )
}